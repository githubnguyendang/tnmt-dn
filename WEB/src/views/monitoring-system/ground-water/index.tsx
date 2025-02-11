import { useState, useEffect, useRef } from 'react'

// ** MUI Imports
import { Grid, Box, Paper, Typography } from '@mui/material'

// ** Components Imports
import TableComponent, { TableColumn } from 'src/@core/components/table'
import DisplayOperatingStatus from 'src/@core/components/monitoring-page/check-status'
import GetConstructionTypeId from 'src/@core/components/get-construction-type'
import { getData } from 'src/api/axios'
import { ConverterCood } from 'src/@core/components/map/convert-coord'
import MonitoringSystemToolBar from '../tool-bar'
import MapLegend from 'src/views/construction/MapLegend'

import dynamic from 'next/dynamic'
import { useRouter } from 'next/router'
import { calculateMonitoringData } from 'src/@core/components/calculate-monitoring-data'
import ViewMonitoringSystemData from '../form'
import { formatDateTime } from 'src/@core/components/formater'

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false })

const GroundwaterMonitoring = () => {
  const router = useRouter()
  const [mapCenter, setMapCenter] = useState([15.01, 108.68])
  const [mapZoom, setMapZoom] = useState(9.8)
  const [resData, setResData] = useState<any[]>([])
  console.log(resData)

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
    { id: 'thoiGian', label: 'Thời gian cập nhật', elm: (row: any) => formatDateTime(row.thoiGian) },

    {
      id: '#',
      label: 'Lưu lượng khai thác của từng giếng khoan',
      children: [
        {
          id: 'qktLonNhat',
          label: 'Yêu cầu',
          minWidth: 115,
          align: 'center',
          elm: (row: any) => checkNullValue(row.thongso?.qktLonNhat)
        },
        {
          id: 'MaximumFlowPre',
          label: 'Thực tế ',
          minWidth: 115,
          align: 'center',
          elm: (row: any) => checkNullValue(row.MaximumFlowPre)
        },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          align: 'center',
          elm: (row: any) => calculateMonitoringData(row.thongso?.hThuongLuu, row.hThuongLuuTT)
        }
      ]
    },
    {
      id: '#',
      label: 'Mực nước trong giếng khai thác ',
      children: [
        {
          id: 'MaximumFlow',
          label: 'Yêu cầu',
          minWidth: 115,
          align: 'center',
          elm: (row: any) => checkNullValue(row.thongso?.mnlkt)
        },
        {
          id: 'MaximumFlowPre',
          label: 'Thực tế ',
          minWidth: 115,
          align: 'center',
          elm: (row: any) => checkNullValue(row.thongso?.mnlkt)
        },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          align: 'center',
          elm: (row: any) => calculateMonitoringData(row.thongso?.hThuongLuu, row.hThuongLuuTT)
        }
      ]
    },
    {
      id: '#',
      label: 'Mực nước trong giếng quan trắc',
      children: [
        { id: 'MaximumFlow', label: 'Yêu cầu', minWidth: 115, elm: (row: any) => checkNullValue(row.thongso?.mnlkt) },
        {
          id: 'MaximumFlowPre',
          label: 'Thực tế ',
          minWidth: 115,
          elm: (row: any) => checkNullValue(row.thongso?.mnlkt)
        },
        {
          id: '',
          label: 'Chênh lệch (+/-)',
          align: 'center',
          elm: (row: any) => calculateMonitoringData(row.thongso?.hThuongLuu, row.hThuongLuuTT)
        }
      ]
    },

    { id: 'actions', label: 'Thao tác', pinned: 'right' }
  ]

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
    'giengkhoan',
    'giengdao',
    'thamdo',
    'hanhnghekhoan',
    'congtrinhkhac_ndd'
  ])

  const handleFilterChange = (data: any) => {
    console.log(data)

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
      <Grid item xs={12} sm={5} md={3}>
        <Typography sx={{ fontStyle: 'italic' }}>Thời gian cập nhật: </Typography>
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

export default GroundwaterMonitoring
