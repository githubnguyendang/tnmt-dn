import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Checkbox, FormControlLabel, FormGroup, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import DeleteData from 'src/@core/components/delete-data'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'
import ThaiLonForm from './form/NguonThaiLonForm'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

const NguonThaiDien_Lon = () => {
  const [data, setData] = useState([])
  const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  const [mapZoom, setMapZoom] = useState(9.8)
  const [selectedRiver, setSelectedRiver] = useState<any>()
  const [loading, setLoading] = useState(false)
  const [showLabel, setShowLabel] = useState(false)
  const [postSuccess, setPostSuccess] = useState(false)

  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', rowspan: 2 },
    {
      id: '#',
      label: 'Phân đoạn sông',
      rowspan: 2,
      align: 'left',
      minWidth: 200,
      elm: (row: any) => (
        <Typography className='btnShowFilePdf' onClick={() => handleRiverSelection(row)}>
          {row.phanDoanSong?.phanDoan}
        </Typography>
      )
    },
    {
      id: '#',
      label: (
        <Box>
          Tên đoạn <br /> sông
        </Box>
      ),
      rowspan: 2,
      align: 'left',
      minWidth: 100,
      elm: (row: any) => <span>{row.phanDoanSong.tenDoanSong}</span>
    },
    {
      id: 'chieuDai',
      label: (
        <Box>
          Chiều dài <br /> đoạn sông <br /> (km)
        </Box>
      ),
      rowspan: 2,
      align: 'left',
      minWidth: 100,
      elm: (row: any) => <span>{row.phanDoanSong.chieuDai}</span>
    },
    {
      id: 'soLon',
      label: (
        <Box>
          Số lợn
          <br /> (con) <br />
        </Box>
      ),
      rowspan: 2,
      align: 'left',
      minWidth: 100
    },
    {
      id: 'soDe',
      label: (
        <Box>
          Số dê
          <br /> (con) <br />
        </Box>
      ),
      rowspan: 2,
      align: 'left',
      minWidth: 100
    },
    {
      id: 'soGiaSucKhac',
      label: (
        <Box>
          Số gia súc khác
          <br /> (con) <br />
        </Box>
      ),
      rowspan: 2,
      align: 'left',
      minWidth: 150
    },
    {
      id: 'heSoSuyGiam',
      label: (
        <Box>
          Hệ số suy giảm dọc đường <br /> hay hệ số dòng chảy
        </Box>
      ),
      rowspan: 2,
      align: 'left'
    },
    {
      id: '#',
      label: (
        <Box>
          TẢI LƯỢNG Ô NHIỄM (PLU) NGUỒN THẢI DIỆN (LỢN, DÊ...) <br />
          (g/người/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ctLonBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctLonCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctLonAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctLonTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctLonTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctLonTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctLonColiform',
          label: (
            <Box>
              Tổng P <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left'
        }
      ]
    },

    //lnn
    {
      id: '#',
      label: (
        <Box>
          TẢI LƯỢNG THÔNG SỐ CHẤT LƯỢNG NƯỚC CÓ TRONG NGUỒN THẢI DIỆN (CHĂN NUÔI GIA SÚC)
          <br /> Lt_dien_Lon (kg/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ltLonBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltLonCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltLonAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltLonTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltLonTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltLonTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltLonColiform',
          label: (
            <Box>
              Tổng P <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left'
        }
      ]
    },
    {
      id: 'ghiChu',
      label: 'Ghi chú',
      rowspan: 2,
      align: 'left'
    },

    { id: 'actions', label: 'Thao tác', rowspan: 2, align: 'center', pinned: 'right' }
  ]

  // Tạo ref cho container chứa bản đồ
  const mapRef = useRef<HTMLDivElement>(null)

  const handleRiverSelection = useCallback(async river => {
    setSelectedRiver(river)
    try {
      const kmlDoc = await fetchAndParseKML(`${river.phanDoanSong.fileKML}`)
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

  useEffect(() => {
    async function getDataReport1() {
      setLoading(true)
      await getData('DuLieuNguonNuocThaiLon/danh-sach')
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
  }, [postSuccess])

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
          <Grid container className='_flexEnd' spacing={2} sx={{ p: 2 }}>
            <Grid item>
              <ExportTableToExcel tableId='du-lieu-nguon-thai-gia-lon' filename='dulieuthaigialon.csv' />
            </Grid>
            <Grid item>
              <ThaiLonForm isEdit={false} setPostSuccess={handlePostSuccess} />
            </Grid>
          </Grid>
          <TableComponent
            columns={columnsTable}
            rows={data}
            id='phan_doan_song'
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box className='group_btn'>
                <ThaiLonForm isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'du-lieu-nguon-thai'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default NguonThaiDien_Lon
