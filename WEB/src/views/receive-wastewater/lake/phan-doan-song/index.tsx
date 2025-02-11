//React Imports
import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'

//MUI Imports

import { getData } from 'src/api/axios'
import { Grid, Box, Paper, Typography, FormGroup, FormControlLabel, Checkbox } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import DeleteData from 'src/@core/components/delete-data'
import PhanDoanSongForm from './PhanDoanSongForm'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import ToolBar from '../toolbar'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

// eslint-disable-next-line react-hooks/rules-of-hooks
const PhanDoanSongTiepNhanNuocThai = () => {
  const [data, setData] = useState([])
  const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  const [mapZoom, setMapZoom] = useState(9)
  const [selectedRiver, setSelectedRiver] = useState<any>(null)
  const [showLabel, setShowLabel] = useState(false)
  const [loading, setLoading] = useState(false)
  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  const [paramsFilter, setParamsFilter] = useState({
    phanDoan: ''
  })
  const handleFilterChange = (data: any, postSuccess: boolean | undefined) => {
    setParamsFilter(data)
    if (postSuccess !== undefined) {
      setPostSuccess(postSuccess)
    }
  }

  // Tạo ref cho container chứa bản đồ
  const mapRef = useRef<HTMLDivElement>(null)
  const handleRiverSelection = useCallback(async river => {
    setSelectedRiver(river)
    console.log(river.fileKML)

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
      minWidth: 190,
      elm: (row: any) => (
        <Typography className='btnShowFilePdf' onClick={() => handleRiverSelection(row)}>
          {row?.phanDoan}
        </Typography>
      )
    },
    {
      id: 'luuVucSong',
      label: 'Lưu vực sông',
      align: 'left',
      minWidth: 150
    },
    {
      id: 'song',
      label: 'Sông',
      align: 'left',
      minWidth: 150
    },
    {
      id: 'tenDoanSong',
      label: 'Tên đoạn sông',
      align: 'left',
      minWidth: 200
    },

    {
      id: '#',
      label: 'Tọa độ (VN2000, múi chiếu 30, kinh tuyến trục 107045’)',
      children: [
        {
          id: 'xDau',
          label: 'Điểm đầu X'
        },
        {
          id: 'yDau',
          label: 'Điểm đầu Y'
        },
        {
          id: 'xCuoi',
          label: 'Điểm cuối X'
        },
        {
          id: 'xCuoi',
          label: 'Điểm cuối Y'
        }
      ]
    },
    {
      id: 'diaGioiHanhChinh',
      label: 'Địa giới hành chính',
      align: 'left'
    },
    {
      id: 'mucDichSuDung',
      label: (
        <Box>
          Mục đích sử dụng nước <br /> theo QCVN 08:2023/BTNMT
        </Box>
      ),
      align: 'left'
    },
    {
      id: 'chatLuongNuoc',
      label: (
        <Box>
          CLN <br /> theo <br /> QCVN 08:2023
        </Box>
      ),
      align: 'left'
    },

    {
      id: 'ghiChu',
      label: 'Ghi chú',
      align: 'left'
    },

    { id: 'actions', label: 'Thao tác', align: 'center', pinned: 'right' }
  ]

  useEffect(() => {
    async function getDataReport1() {
      setLoading(true)
      await getData('PhanDoanSong/danh-sach', paramsFilter)
        .then(data => {
          console.log(data)
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
  }, [postSuccess, paramsFilter])

  useEffect(() => {
    if (!selectedRiver) {
      setMapCenter([15.012172, 108.68]) // Mặc định trung tâm
      setMapZoom(9.5) // Mặc định zoom
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
                label='Hiển thị số thứ tự đoạn sông'
              />
            </FormGroup>
          </Box>
          <MapDoanSong
          center={mapCenter}
          zoom={mapZoom}
          mapData={selectedRiver}
          dischargeData={data}
          selectedKmlFile={selectedRiver ? selectedRiver.fileKML : null}
          loading={loading}
          showLabel={showLabel}
        />
        </Paper>
      </Grid>
      <Grid xs={12} md={12}>
        <Grid className='_text_center'>
          <Typography style={{ color: 'red', fontWeight: 700 }} className='font-weight-bold' sx={{ mt: 3 }} variant='h6'>
            TỔNG HỢP PHÂN ĐOẠN SÔNG TỈNH QUẢNG NGÃI
          </Typography>
        </Grid>
        <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <ToolBar onChange={handleFilterChange} tabId='pds'/>

          <TableComponent
            columns={columnsTable}
            rows={data}
            id='phan_doan_song'
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box className='group_btn'>
                <PhanDoanSongForm isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'PhanDoanSong'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default PhanDoanSongTiepNhanNuocThai
