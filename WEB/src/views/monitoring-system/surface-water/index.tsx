import { useState, useEffect, useRef } from 'react'

// ** MUI Imports
import { Grid, Box, Paper, Typography } from '@mui/material'

// ** Components Imports
import TableComponent, { TableColumn } from 'src/@core/components/table'
import DisplayOperatingStatus from 'src/@core/components/monitoring-page/check-status'

import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import MonitoringSystemToolBar from '../tool-bar'
import { useRouter } from 'next/router'
import { calculateMonitoringData } from 'src/@core/components/calculate-monitoring-data'
import GetConstructionTypeId from 'src/@core/components/get-construction-type'
import { ConverterCood } from 'src/@core/components/map/convert-coord'
import MapLegend from 'src/views/construction/MapLegend'
import ViewMonitoringSystemData from '../form'
import { formatDateTime } from 'src/@core/components/formater'

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false })

const SurfaceWaterMonitoring = () => {
  const router = useRouter()
  const [mapCenter, setMapCenter] = useState([15.02, 108.68])
  const [mapZoom, setMapZoom] = useState(10)
  const [resData, setResData] = useState<any[]>([])
  const [loading, setLoading] = useState(false)

  const [dataFiltered, setDataFiltered] = useState([])

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', align: 'center' },
    {
      id: 'tenCT',
      label: 'Tên công trình',
      minWidth: 240,
      pinned: 'left',
      elm: (row: any) => (
        <Typography className='btnShowFilePdf' onClick={() => zoomConstruction(ConverterCood(row.y, row.x))}>
          {row.tenCT}
        </Typography>
      )
    },
    { id: 'loi', label: 'Trạng thái vận hành', elm: (row: any) => <DisplayOperatingStatus data={row} /> },
    { id: 'thoiGian', label: 'Thời gian cập nhật', elm: (row: any) => formatDateTime(row.thoiGian)},


    {
      id: 'hHaLuuTT',
      label: (
        <span>
          Mực nước <br /> hạ lưu (m)
        </span>
      ),
      align: 'center',
      minWidth: 115,
      elm: (row: any) => checkNullValue(row.thongso?.hHaLuu)
    },
    {
      id: 'dungTichToanBo',
      label: (
        <span>
          Dung tích hồ <br /> (triệu m<sup>3</sup>)
        </span>
      ),
      align: 'center',
      minWidth: 115,
      elm: (row: any) => checkNullValue(row.thongso?.dungTichToanBo)
    },
    {
      id: '#',
      label: 'Mực nước thượng lưu hồ (m)',
      children: [
        {
          id: 'hThuongLuu',
          label: 'Ngưỡng tràn',
          elm: (row: any) => checkNullValue(row.thongso?.hThuongLuu),
          align: 'center',
          minWidth: 115
        },
        {
          id: 'hThuongLuuTT',
          label: 'Thực tế ',
          align: 'center',
          minWidth: 115,
          elm: (row: any) => checkNullValue(row.hThuongLuuTT)
        },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          elm: (row: any) => calculateMonitoringData(row.thongso?.hThuongLuu, row.hThuongLuuTT),
          align: 'center'
        }
      ]
    },
    {
      id: '#',
      label: (
        <span>
          Lưu lượng xả qua tràn (m<sup>3</sup>/s)
        </span>
      ),
      children: [
        {
          id: 'qXaTran',
          label: 'Ngưỡng tràn',
          elm: (row: any) => checkNullValue(row.thongso?.qXaTran),
          align: 'center',
          minWidth: 115
        },
        {
          id: 'qXaTranTT',
          label: 'Thực tế',
          align: 'center',
          minWidth: 115,
          elm: (row: any) => checkNullValue(row.qXaTranTT)
        },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          elm: (row: any) => calculateMonitoringData(row.thongso?.qXaTran, row.qXaTranTT),
          align: 'center'
        }
      ]
    },
    {
      id: '#',
      label: (
        <span>
          Lưu lượng xả nhà máy (m<sup>3</sup>/s)
        </span>
      ),
      children: [
        {
          id: 'qktLonNhat',
          label: 'Ngưỡng tràn',
          elm: (row: any) => checkNullValue(row.thongso?.qktLonNhat),
          align: 'center',
          minWidth: 115
        },
        {
          id: 'qMaxTT',
          label: 'Thực tế',
          align: 'center',
          minWidth: 115,
          elm: (row: any) => checkNullValue(row.qXaMaxTT)
        },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          elm: (row: any) => calculateMonitoringData(row.thongso?.qktLonNhat, row.qXaMaxTT),
          align: 'center'
        }
      ]
    },
    {
      id: '#',
      label: (
        <span>
          Lưu lượng xả duy trì DCTT (m<sup>3</sup>/s)
        </span>
      ),
      children: [
        {
          id: 'qtt',
          label: 'Ngưỡng tràn',
          elm: (row: any) => checkNullValue(row.thongso?.qtt),
          align: 'center',
          minWidth: 115
        },
        { id: 'dctttt', label: 'Thực tế ', minWidth: 115, elm: (row: any) => checkNullValue(row.dctttt) },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          elm: (row: any) => calculateMonitoringData(row.thongso?.qtt, row.dctttt),
          align: 'center'
        }
      ]
    },
    {
      id: '#',
      label: (
        <span>
          Lưu lượng về hạ du (m<sup>3</sup>/s)
        </span>
      ),
      children: [
        { id: 'qtt', label: 'Ngưỡng tràn', align: 'center', minWidth: 115 },
        { id: 'qMinTT', label: 'Thực tế ', minWidth: 115 },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          align: 'center',
          elm: (row: any) => calculateSumFlow(row.qMaxTT, row.qXaTranTT, row.qMinTT)
        }
      ]
    },
    { id: 'actions', label: 'Thao tác',pinned: 'right' }
  ]

  const calculateSumFlow = (value1: any, value2: any, value3: any) => {
    let result = 0
    if (value1 == null || value2 == null || value3 == null) {
      return <span style={{ fontWeight: 'bold', color: 'green' }}>0.00</span>
    } else {
      result += parseFloat(value1) + parseFloat(value2) + parseFloat(value3)

      return result
    }
  }

  const checkNullValue = (value: any) => {
    if (value == null || value == undefined) {
      return <span>-</span>
    } else {
      return value
    }
  }

  const zoomConstruction = (coords: any) => {
    setMapCenter(coords)
    setMapZoom(13)
    window.scrollTo({
      top: 0,
      left: 0,
      behavior: "smooth"
    });
  }

  const isMounted = useRef(true)
  useEffect(() => {
    isMounted.current = true

    return () => {
      isMounted.current = false
    }
  }, [])

  
  const [paramsFilter, setParamsFilter] = useState({
    tenct: null,
    loai_ct: GetConstructionTypeId(router),
    tochuc_canhan: 0
  })

  useEffect(() => {
    const getDataConstructions = async () => {
      setLoading(true)
      getData('GiamSatSoLieu/danhsach', paramsFilter)
        .then(data => {
          if (isMounted.current) {
            setResData(data)
          }
        })
        .catch(error => {
          console.log(error)
        })
        .finally(() => {
          setLoading(false)
        })
    }
    getDataConstructions()
    
  }, [paramsFilter])


  const [initConsType, setInitConstype] = useState<any>([
    'nuocmat',
    'thuydien',
    'hochua',
    'trambom',
    'tramcapnuoc',
    'conglaynuoc',
    'nhamaynuoc'
  ])

  const handleFilterChange = (data: any) => {
    console.log(data);
    
    setParamsFilter(data)
  }

  useEffect(() => {
    const filteredData: any = resData.filter((item: { [key: string]: any }) =>
      initConsType.some((keyword: any) =>
        item['loaiCT']?.['maLoaiCT']?.toString().toLowerCase().includes(keyword.toLowerCase())
      )
    )
    setDataFiltered(filteredData)
  }, [initConsType, resData])

  const handleConsTypeChange = (data: any) => {
    setInitConstype(data)
  }

  return (
    <Grid container spacing={4}>
      <Grid item xs={12} sm={12} md={12} sx={{ height: '55vh', overflow: 'hidden' }}>
        <Paper elevation={3} sx={{ height: '100%', position: 'relative' }}>
          <Box className='map-legend' sx={{ background: 'white', pl: 2, zIndex: 999, height: 'auto', top: '15px' }}>
            <MapLegend onChange={handleConsTypeChange} />
          </Box>
          <Map center={mapCenter} zoom={mapZoom} mapData={dataFiltered} loading={false} />
        </Paper>
      </Grid>
      <Grid item xs={12} sm={12} md={12}>
        <MonitoringSystemToolBar onChange={handleFilterChange} />
        <TableComponent
          loading={loading}
          columns={columnsTable}
          rows={dataFiltered}
          pagination={true}
          actions={(row) => (
            <Box>
              <ViewMonitoringSystemData data={row}/>
            </Box>
          )}
        />
      </Grid>
    </Grid>
  )
}

export default SurfaceWaterMonitoring
