import { Box, Tab } from '@mui/material'
import { useState } from 'react'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import Mualuuvuc from './mualuuvuc';
import Muadiaphuong from './muadiaphuong';
import MuaNgayTram from './mua-ngay-tram';

const Kiemkemua = () => {
  const [idTrang, setIdTrang] = useState('mualuuvuc');
  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setIdTrang(newValue);
  };

  return (
    <TabContext value={idTrang}>
      <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <TabList onChange={handleChange} aria-label="lab API tabs example">
          <Tab label="Phân bố mưa theo lưu vực" value="mualuuvuc" />
          <Tab label="Phân bố mưa theo địa phương" value="muadiaphuong" />
          <Tab label="Mưa ngày theo trạm" value="MuaNgayTram" />
        </TabList>
      </Box>
      <TabPanel value="mualuuvuc">
        <Mualuuvuc />
      </TabPanel>
      <TabPanel value="muadiaphuong">
        <Muadiaphuong />
      </TabPanel>
      <TabPanel value="MuaNgayTram">
        <MuaNgayTram />
      </TabPanel>

    </TabContext>


  )

}

export default Kiemkemua
