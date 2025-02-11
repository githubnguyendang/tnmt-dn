import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import DeleteData from 'src/@core/components/delete-data'
import ToolBar from '../../toolbar'
import CreateWasteFormDB from './wasteWaterForm'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

const WasteWaterDetailsDB = () => {
  const [data, setData] = useState([])
  console.log(data);
  
  const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  const [mapZoom, setMapZoom] = useState(9)
  const [selectedRiver, setSelectedRiver] = useState<any>()
  const [loading, setLoading] = useState(false)
  const [postSuccess, setPostSuccess] = useState(false)

  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }


  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT' },
    {
      id: '#',
      label: 'Phân đoạn sông',
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

      align: 'left',
      minWidth: 100,
      elm: (row: any) => <span>{row.phanDoanSong.chieuDai}</span>
    },
    {
      id: 'luuLuongDongChayDB',
      label: (
        <Box>
          {' '}
          Lưu lượng <br /> dòng chảy <br /> Qs(m3/s)
        </Box>
      ),

      align: 'left'
    },
    {
      id: '#',
      label: (
        <Box>
          {' '}
          KẾT QUẢ PHÂN TÍCH THÔNG SỐ CHẤT LƯƠNG NƯỚC MẶT <br />
          Cnn[-]
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'cnnBODDB',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnCODDB',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnAmoniDB',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnTongNDB',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnTongPDB',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnTSSDB',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnColiformDB',
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
          {' '}
          TẢI LƯỢNG Ô NHIỄM NGUỒN NƯỚC HIỆN CÓ <br />
          Lnn (kg/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'lnnBODDB',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnCODDB',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnAmoniDB',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnTongNDB',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnTongPDB',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnTSSDB',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnColiformDB',
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
      id: '#',
      label: (
        <Box>
          {' '}
          GIÁ TRỊ GIỚI HẠN THÔNG SỐ CHẤT LƯỢNG NƯỚC THEO TIÊU CHUẨN QCVN 08:2023/BTNMT <br />
          Cqc [-]
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'cqcBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <span>{row.thongSoCLNDuBao.bod}</span>
        },
        {
          id: 'cqcCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <span>{row.thongSoCLNDuBao.cod}</span>
        },
        {
          id: 'cqcAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <span>{row.thongSoCLNDuBao.amoni}</span>
        },
        {
          id: 'cqcTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tongN}</span>
        },
        {
          id: 'cqcTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tongP}</span>
        },
        {
          id: 'cqcTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tss}</span>
        },
        {
          id: 'cqcColiform',
          label: (
            <Box>
              Tổng P <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tongColiform}</span>
        }
      ]
    },
    {
      id: '#',
      label: (
        <Box>
          {' '}
          TẢI LƯỢNG TỐI ĐA CỦA THÔNG SỐ CHẤT LƯỢNG NƯỚC MẶT <br />
          Ltd (kg/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ltdBODDB',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdCODDB',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdAmoniDB',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdTongNDB',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdTongPDB',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdTSSDB',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdColiformDB',
          label: (
            <Box>
              Tổng <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left'
        }
      ]
    },
    
    { id: 'actions', label: 'Thao tác', align: 'center', pinned: 'right' }
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

  const mapRef = useRef<HTMLDivElement>(null)

  const handleRiverSelection = useCallback(async (river: any) => {
    setSelectedRiver(river)
    try {
      const kmlDoc = await fetchAndParseKML(`${river.phanDoanSong.fileKML}`)
      const bounds = calculateBounds(kmlDoc)
      if (bounds) {
        setMapCenter(bounds.center)
        setMapZoom(bounds.zoom)
      }

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
          getData('DuLieuNguonNuocNhanDB/danh-sach', paramsFilter),
        ])
        setData(dataResponse)
      } catch (error) {
        console.log(error)
      } finally {
        setLoading(false)
      }
    }
    getDataReport1()
  }, [selectedRiver, postSuccess, paramsFilter])

  useEffect(() => {
    if (!selectedRiver) {
      setMapCenter([15.012172, 108.676488])
      setMapZoom(9)
    }
  }, [selectedRiver, paramsFilter])

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
          <ToolBar onChange={handleFilterChange} tabId='dubaonguonnuocnhan'/>

          <TableComponent
            columns={columnsTable}
            rows={data}
            id='phan_doan_song'
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box className='group_btn'>
                <CreateWasteFormDB isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'du-lieu-nguon-thai'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default WasteWaterDetailsDB
