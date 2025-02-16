import React, { useState, SyntheticEvent, useEffect, useRef } from 'react'
import { Assessment } from '@mui/icons-material'
import { Grid, IconButton, Tooltip, Box, Tab } from '@mui/material'
import DialogsControlFullScreen from 'src/@core/components/dialog-control-full-screen'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import MonitoringSFData from './du_lieu_giam-sat'
import MonitoringSFChart from './bieu_do_giam_sat'
import { getData } from 'src/api/axios'
import dayjs from 'dayjs'
import FilterToolbar from './thanh_cong_cu'

interface HeThongGiamSatProps {
  dataCons: any // Add data to props
}

const HeThongGiamSat: React.FC<HeThongGiamSatProps> = ({ dataCons }) => {
  const [value, setValue] = useState('1');
  const { data } = dataCons;
  const handleChangeTab = (event: SyntheticEvent, newValue: string) => {
    setValue(newValue);
  };

  const [resData, setResData] = useState<any[]>([]);
  const [startDate, setStartDate] = useState<dayjs.Dayjs | null>(dayjs().subtract(24, 'hour')); // Mặc định 24 giờ trước
  const [endDate, setEndDate] = useState<dayjs.Dayjs | null>(dayjs()); // Mặc định ngày hiện tại

  const isMounted = useRef(true);

  useEffect(() => {
    isMounted.current = true;

    return () => {
      isMounted.current = false;
    };
  }, []);

  const getDataConstructions = async () => {
    if (!startDate || !endDate) return; // Kiểm tra giá trị null
  
    const format = 'YYYY-MM-DD HH:mm:ss.SSSSSS'; // Định dạng API yêu cầu
    const encodedStartDate = encodeURIComponent(startDate.format(format));
    const encodedEndDate = encodeURIComponent(endDate.format(format));
  
    try {
      const result = await getData(
        `GiamSatSoLieu/thong-tin?ConstructionCode=${data.maCT}&StartDate=${encodedStartDate}&EndDate=${encodedEndDate}`,
        {}
      );
  
      if (isMounted.current) {
        setResData(result);
      }
    } catch (error) {
      console.error('Lỗi khi gọi API:', error);
    }
  };
  
  
  // Gọi API khi `startDate` hoặc `endDate` thay đổi
  useEffect(() => {
    getDataConstructions();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [startDate, endDate, data?.maCT]);

  return (
    <Grid>
      <TabContext value={value}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList onChange={handleChangeTab} aria-label="ground water reserve">
            <Tab label="Số liệu vận hành" value="1" />
            <Tab label="Đồ thị vận hành" value="2" />
          </TabList>
        </Box>
        <TabPanel value="1">
          <FilterToolbar
            startDate={startDate}
            endDate={endDate}
            setStartDate={setStartDate}
            setEndDate={setEndDate}
            onFilter={getDataConstructions}
          />
          <MonitoringSFData dataStorage={resData} dataCons={data} />
        </TabPanel>
        <TabPanel value="2">
          <FilterToolbar
            startDate={startDate}
            endDate={endDate}
            setStartDate={setStartDate}
            setEndDate={setEndDate}
            onFilter={getDataConstructions}
          />
          <MonitoringSFChart dataStorage={resData} dataCons={data} />
        </TabPanel>
      </TabContext>
    </Grid>
  );
};

interface MonitoringSystemProps {
  data?: any
}

const HeThongGiamSatDuLieuView: React.FC<MonitoringSystemProps> = ({ data }) => {
  const formTitle = 'Thông tin số liệu giám sát vận hành'

  return (
    <DialogsControlFullScreen>
      {(openDialogs: (content: React.ReactNode, title: React.ReactNode) => void) => (
        <Box>
          <Tooltip title='Xem chi tiết'>
            <IconButton onClick={() => openDialogs(<HeThongGiamSat dataCons={{ data }} />, formTitle)}>
              <Assessment className='tableActionBtn' />
            </IconButton>
          </Tooltip>
        </Box>
      )}
    </DialogsControlFullScreen>
  )
}

export default HeThongGiamSatDuLieuView
