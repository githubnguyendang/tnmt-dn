import { useState, useEffect, useRef } from 'react'

// ** MUI Imports
import { Grid, Box, Typography, Paper, FormGroup, FormControlLabel, Checkbox } from '@mui/material'

// ** Components Imports
import TableComponent, { TableColumn } from 'src/@core/components/table'
import DisplayOperatingStatus from 'src/@core/components/monitoring-page/check-status'
import GetConstructionTypeId from 'src/@core/components/get-construction-type'
import { ConverterCood } from 'src/@core/components/map/convert-coord'
import MapLegend from 'src/views/construction/MapLegend'

import dynamic from 'next/dynamic'
import { useRouter } from 'next/router'
import { getData } from 'src/api/axios'
import MonitoringSystemToolBar from 'src/views/monitoring-system/tool-bar'
import ViewMonitoringSystemData from 'src/views/monitoring-system/form'
import { formatDateTime } from 'src/@core/components/formater'

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false })

// id of columnsTable is parameter to bind ex: get LicseFk.BasinId: id: 'License_Fk.BasinId'

const SurfaceWaterMeasuresing = () => {
  const router = useRouter()
  const [mapCenter, setMapCenter] = useState([15.01, 108.68])
  const [mapZoom, setMapZoom] = useState(9.8)
  const [showLabel, setShowLabel] = useState(false)
  const [resData, setResData] = useState<any[]>([])
  const [columns, setColumns] = useState<any[]>([])
  const [loading, setLoading] = useState(false)


  const [dataFiltered, setDataFiltered] = useState([])

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', align: 'center' },
    {
      id: 'tenCT',
      label: 'Tên công trình',
      minWidth: 350,
      pinned: 'left',
      elm: (row: any) => (
        <Typography className='btnShowFilePdf' onClick={() => zoomConstruction(ConverterCood(row.y, row.x))}>
          {row.tenCT}
        </Typography>
      )
    },
    { id: '#', label: 'Trạng thái vận hành', elm: (row: any) => <DisplayOperatingStatus data={row} /> },
    { id: 'thoiGian', label: 'Thời gian cập nhật', elm: (row: any) => formatDateTime(row.thoiGian)},

    {
      id: 'hHaLuuTT',
      label: (
        <span>
          Mực nước <br /> hạ lưu (m)
        </span>
      ),
    },
    {
      id: 'dungTichTT',
      label: (
        <span>
          Dung tích hồ <br /> (triệu m<sup>3</sup>)
        </span>
      ),
    },
    {
      id: 'hThuongLuuTT',
      label: (
        <span>
          Mực nước <br /> thượng lưu hồ (m)
        </span>
      ),
    },
    {
      id: 'qXaTranTT',
      label: (
        <span>
          Lưu lượng <br /> xả qua tràn (m3/s)
        </span>
      )
    },
    {
      id: 'qXaMaxTT',
      label: (
        <span>
          Lưu lượng <br /> lớn nhất (m3/s)
        </span>
      )
    },
    {
      id: 'dctttt',
      label: (
        <span>
          Lưu lượng xả
          <br /> duy trì DCTT (m3/s)
        </span>
      )
    },
    {
      id: '#',
      label: (
        <span>
          Lưu lượng <br /> về hạ du (m3/s)
        </span>
      )
    },
    {
      id: '#',
      label: 'Chất lượng nước trong quá trình khai thác',
      colspan: 7,
      children: [
        { id: 'Nhietdo', label: 'Nhiệt độ (°C)', elm: (row: any) => <span>{row?.nhietDo}</span> },
        { id: 'pH', label: 'pH ', elm: (row: any) => <span>{row?.ph}</span>  },
        { id: 'BOD5', label: 'BOD5' , elm: (row: any) => <span>{row?.bod}</span> },
        { id: 'COD', label: 'COD', elm: (row: any) => <span>{row?.cod}</span>  },
        { id: 'DO', label: 'DO', elm: (row: any) => <span>{row?.do}</span>  },
        { id: 'TSS', label: 'TSS', elm: (row: any) => <span>{row?.tss}</span>  },
        { id: 'nH4', label: 'NH4+', elm: (row: any) => <span>{row?.nH4}</span>  },
      ]
    },
    { id: 'actions', label: 'Thao tác' }
  ]

  const isMounted = useRef(true)
  useEffect(() => {
    isMounted.current = true

    return () => {
      isMounted.current = false
    }
  }, [])

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

    setColumns(columnsTable)

    // fetchData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  const [paramsFilter, setParamsFilter] = useState({
    tenct: null,
    loai_ct: GetConstructionTypeId(router),
    huyen: 0,
    xa: 0,
    song: 0,
    luuvuc: 0,
    tieu_luuvuc: 0,
    tang_chuanuoc: 0,
    tochuc_canhan: 0,
    nguonnuoc_kt: null
  })

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

  const zoomConstruction = (coords: any) => {
    setMapCenter(coords)
    setMapZoom(13)
    window.scrollTo({
      top: 0,
      left: 0,
      behavior: "smooth"
    });
  }

  return (
    <Grid container spacing={4}>
      <Grid item xs={12} sm={12} md={12} sx={{ height: '55vh', overflow: 'hidden' }}>
        <Paper elevation={3} sx={{ height: '100%', position: 'relative' }}>
          <Box className='map-legend' sx={{ background: 'white', px: 2, zIndex: 999, height: 'auto', top: '15px' }}>
            <FormGroup>
              <FormControlLabel
                sx={{ m: 0 }}
                control={<Checkbox sx={{ p: 1 }} onClick={() => setShowLabel(!showLabel)} />}
                label='Hiển thị tên công trình'
              />
            </FormGroup>
            <MapLegend onChange={handleConsTypeChange} />
          </Box>
          <Map center={mapCenter} zoom={mapZoom} showLabel={showLabel} mapData={dataFiltered} loading={false} />
        </Paper>
      </Grid>
      <Grid item xs={12} sm={12} md={12}>
        <MonitoringSystemToolBar onChange={handleFilterChange} />
        <TableComponent
          loading={loading}
          columns={columns}
          rows={dataFiltered}
          pagination={true}
          actions={(row) => (
            <Box>
              <ViewMonitoringSystemData data={row} />
            </Box>
          )}
        />
      </Grid>
    </Grid>
  )
}

export default SurfaceWaterMeasuresing
