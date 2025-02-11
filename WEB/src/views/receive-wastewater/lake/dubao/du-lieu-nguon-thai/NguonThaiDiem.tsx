import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import DeleteData from 'src/@core/components/delete-data'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'
import ThaiDiemFormDB from './form/NguonThaiDiemForm'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

const NguonThaiDiemDB = () => {
  const [data, setData] = useState([])
  const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  const [mapZoom, setMapZoom] = useState(9.8)
  const [selectedRiver, setSelectedRiver] = useState<any>()
  const [loading, setLoading] = useState(false)

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
      label: 'Sông',
      rowspan: 2,
      align: 'left',
      minWidth: 200,
      elm: (row: any) => <span>{row.phanDoanSong?.song}</span>
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
      minWidth: 150,
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
      id: 'luuLuongXaThaiDB',
      label: (
        <Box>
          Lưu lượng <br /> xả max <br /> Qxt <br /> (m³/s)
        </Box>
      ),
      rowspan: 2,
      align: 'left'
    },
    {
      id: '#',
      label: (
        <Box>
          {' '}
          KẾT QUẢ PHÂN TÍCH THÔNG SỐ CHẤT LƯỢNG NƯỚC NGUỒN THẢI ĐIỂM <br />
          Ct_diem[-]
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ctdiemBODDB',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemCODDB',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemAmoniDB',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemTongNDB',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemTongPDB',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemTSSDB',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemColiformDB',
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
          TẢI LƯỢNG THÔNG SỐ CHẤT LƯỢNG NƯỚC CÓ TRONG NGUỒN THẢI ĐIỂM
          <br /> Lt_diem (kg/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ltdiemBODDB',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemCODDB',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemAmoniDB',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemTongNDB',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemTongPDB',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemTSSDB',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemColiformDB',
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
      try {
        const [dataResponse] = await Promise.all([
          getData('DuLieuNguonNuocThaiDiemDB/danh-sach')
        ])
        setData(dataResponse)
      } catch (error) {
        console.log(error)
      } finally {
        setLoading(false)
      }
    }
    getDataReport1()
  }, [selectedRiver, postSuccess])

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
          <MapDoanSong
            center={mapCenter}
            zoom={mapZoom}
            mapData={selectedRiver}
            selectedKmlFile={selectedRiver ? selectedRiver.phanDoanSong.fileKML : null}
            loading={loading}
          />
        </Paper>
      </Grid>
      <Grid item xs={12}>
        <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <Grid container className='_flexEnd' spacing={2} sx={{ p: 2 }}>
            <Grid item>
              <ExportTableToExcel tableId='du-lieu-nguon-thai-diem' filename='dulieuthaidiem.csv' />
            </Grid>
            <Grid item>
              <ThaiDiemFormDB isEdit={false} setPostSuccess={handlePostSuccess} />
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
                <ThaiDiemFormDB isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'du-lieu-nguon-thai'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default NguonThaiDiemDB
