import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Checkbox, FormControlLabel, FormGroup, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import FormatCellValue from 'src/@core/components/calculate-data-river'
import ToolBar from '../toolbar'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

const TaiLuongONhiem = () => {
  const [data, setData] = useState([])
  const [showLabel, setShowLabel] = useState(false)
  const [mapCenter, setMapCenter] = useState([15.012172, 108.68])
  const [mapZoom, setMapZoom] = useState(9.8)
  const [selectedRiver, setSelectedRiver] = useState<any>()
  const [loading, setLoading] = useState(false)
  const [postSuccess, setPostSuccess] = useState(false)
  
  // Tạo ref cho container chứa bản đồ
  const mapRef = useRef<HTMLDivElement>(null)
  const handleRiverSelection = useCallback(async river => {
    setSelectedRiver(river)
    try {
      const kmlDoc = await fetchAndParseKML(`${river.fileKML}`)
      const bounds = calculateBounds(kmlDoc)
      if (bounds) {
        setMapCenter(bounds.center)
        setMapZoom(bounds.zoom)
      }

      // Cuộn bản đồ vào tầm nhìn
      if (mapRef.current) {
        mapRef.current.scrollIntoView({ behavior: 'smooth' })
      }
    } catch (error) {
      console.error('Error loading KML:', error)
    }
  }, [])

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT' },
    {
      id: 'phanDoan',
      label: 'Phân đoạn sông',
      align: 'left',
      minWidth: 200,
      elm: (row: any) => (
        <Typography className='btnShowFilePdf' onClick={() => handleRiverSelection(row)}>
          {row?.phanDoan}
        </Typography>
      )
    },
    { id: 'luuVucSong', label: 'Lưu vực sông', align: 'left', minWidth: 200 },

    { id: 'song', label: 'Sông', align: 'left', minWidth: 200 },
    {
      id: 'tenDoanSong',
      label: 'Tên đoạn sông',
      align: 'left',
      minWidth: 150
    },
    {
      id: 'chieuDai',
      label: (
        <Box>
          Chiều dài <br /> đoạn sông <br /> (km)
        </Box>
      ),
      align: 'left',
      minWidth: 100
    },

    {
      id: 'duLieuNguonNuocNhan',
      label: (
        <Box>
          TẢI LƯỢNG TỐI ĐA CỦA THÔNG SỐ CHẤT LƯỢNG NƯỚC MẶT
          <br />
          Ltd (kg/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ltdBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.ltdBOD}</Typography>
        },
        {
          id: 'ltdCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.ltdCOD}</Typography>
        },
        {
          id: 'ltdAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.ltdAmoni}</Typography>
        },
        {
          id: 'ltdTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.ltdTongN}</Typography>
        },
        {
          id: 'ltdTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.ltdTongP}</Typography>
        },
        {
          id: 'ltdTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.ltdTSS}</Typography>
        },
        {
          id: 'ltdColiform',
          label: (
            <Box>
              Tổng P <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.ltdColiform}</Typography>
        }
      ]
    },

    //lnn
    {
      id: 'duLieuNguonNuocNhan',
      label: (
        <Box>
          {' '}
          TẢI LƯỢNG Ô NHIỄM NGUỒN NƯỚC HIỆN CÓ <br />
          Lnn (kg/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'lnnBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.lnnBOD}</Typography>
        },
        {
          id: 'lnnCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.lnnCOD}</Typography>
        },
        {
          id: 'lnnAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.lnnAmoni}</Typography>
        },
        {
          id: 'lnnTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.lnnTongN}</Typography>
        },
        {
          id: 'lnnTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.lnnTongP}</Typography>
        },
        {
          id: 'lnnTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.lnnTSS}</Typography>
        },
        {
          id: 'lnnColiform',
          label: (
            <Box>
              Tổng P <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <Typography className='text_table'>{row.duLieuNguonNuocNhan.lnnColiform}</Typography>
        }
      ]
    },

    {
      id: '#',
      label: (
        <Box>
          TỔNG TẢI LƯỢNG Ô NHIỄM CỦA NGUỒN NƯỚC THẢI <br />
          Lt (kg/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ltBod',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => FormatCellValue(row.ltBod)
        },
        {
          id: 'ltCod',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => FormatCellValue(row.ltCod)
        },
        {
          id: 'ltAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => FormatCellValue(row.ltAmoni)
        },
        {
          id: 'ltTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => FormatCellValue(row.ltTongN)
        },
        {
          id: 'ltTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => FormatCellValue(row.ltTongP)
        },
        {
          id: 'ltTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => FormatCellValue(row.ltTSS)
        },
        {
          id: 'ltColiform',
          label: (
            <Box>
              Tổng <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => FormatCellValue(row.ltColiform)
        }
      ]
    },
    {
      id: 'heSoFS',
      label: 'Hệ số an toàn ',
      align: 'left'
    },
    {
      id: 'ghiChu',
      label: 'Ghi chú',
      align: 'left'
    }
  ]

  const [paramsFilter, setParamsFilter] = useState({
    phanDoan: ''
  })
  const handleFilterChange = (data: any, postSuccess: boolean | undefined) => {
    setParamsFilter(data)
    if (postSuccess !== undefined) {
      setPostSuccess(postSuccess)
    }
  }
  useEffect(() => {
    async function getDataReport1() {
      setLoading(true)
      await getData('PhanDoanSong/tai-luong', paramsFilter)
        .then(data => {
          setData(data)
        })
        .catch(error => {
          console.log(error)
        })
        .finally(() => {
          setLoading(false)
        })
    }
    getDataReport1()
  }, [paramsFilter, postSuccess])

  useEffect(() => {
    if (!selectedRiver) {
      setMapCenter([15.012172, 108.676488])
      setMapZoom(9)
    }
  }, [selectedRiver])

  return (
    <Grid container spacing={2}>
      <Grid item xs={12} md={12} ref={mapRef} sx={{ height: '55vh', overflow: 'hidden' }}>
      <Paper elevation={3} sx={{ height: '100%', position: 'relative' }}>
          <Box className='map-legend' sx={{ background: 'white', px: 2, zIndex: 999, height: 'auto', top: '15px' }}>
          <FormGroup>
              <FormControlLabel
                sx={{ m: 0 }}
                control={<Checkbox sx={{ p: 1 }} onClick={() => setShowLabel(!showLabel)} />}
                label='Hiển thị tên đoạn sông'
              />
            </FormGroup>
          </Box>
          <MapDoanSong
            center={mapCenter}
            zoom={mapZoom}
            mapData={selectedRiver}
            selectedKmlFile={selectedRiver ? selectedRiver.phanDoanSong.fileKML : null}
            loading={loading}
            showLabel={showLabel}
            dischargeData={data}
          />
        </Paper>
      </Grid>
      <Grid item xs={12}>
        <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <ToolBar onChange={handleFilterChange} tabId='tailuong'/>
          <TableComponent columns={columnsTable} rows={data} id='tai-luong-o-nhiem' loading={loading} pagination />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default TaiLuongONhiem
