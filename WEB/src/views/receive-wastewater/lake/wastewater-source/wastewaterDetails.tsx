import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Checkbox, FormControlLabel, FormGroup, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import DeleteData from 'src/@core/components/delete-data'
import CreateWasteForm from './wasteWaterForm'
import MapLegendNuocNhan from './MapLegend'
import ToolBar from '../toolbar'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

const WasteWaterDetails = () => {
  const [data, setData] = useState([])
  const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  const [showLabel, setShowLabel] = useState(false)
  const [mapZoom, setMapZoom] = useState(9)
  const [selectedRiver, setSelectedRiver] = useState<any>()
  const [loading, setLoading] = useState(false)
  const [filterData, setFilterData] = useState<any>()
  const [postSuccess, setPostSuccess] = useState(false)
  const [selectedYear, setSelectedYear] = useState<number | null>(null) // Array to store selected years

  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }

  const handleConsTypeChange = (year: number | null) => {
    setSelectedYear(year)

    if (year !== null) {
      setLoading(true)
      getData('ThongSoDiemQuanTrac/danh-sach', { nam: year })
        .then(filteredDataResponse => {
          setFilterData(filteredDataResponse)
        })
        .catch(error => {
          console.error('Error fetching filtered data:', error)
        })
        .finally(() => {
          setLoading(false)
        })
    } else {
      setFilterData([]) // Clear data if no year is selected
    }
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
      id: 'luuLuongDongChay',
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
          id: 'cnnBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cnnColiform',
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
          id: 'lnnBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'lnnColiform',
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
          align: 'left'
        },
        {
          id: 'cqcCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cqcAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cqcTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cqcTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cqcTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cqcColiform',
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
          TẢI LƯỢNG TỐI ĐA CỦA THÔNG SỐ CHẤT LƯỢNG NƯỚC MẶT <br />
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
          align: 'left'
        },
        {
          id: 'ltdCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdColiform',
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
    {
      id: 'ghiChu',
      label: 'Ghi chú',

      align: 'left'
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
          getData('DuLieuNguonNuocNhan/danh-sach', paramsFilter),
          getData('ThongSoDiemQuanTrac/danh-sach', { nam: selectedYear })
        ])
        setData(dataResponse)
      } catch (error) {
        console.log(error)
      } finally {
        setLoading(false)
      }
    }
    getDataReport1()
  }, [selectedRiver, postSuccess, selectedYear, paramsFilter])

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
          <Box className='map-legend' sx={{ background: 'white', px: 2, zIndex: 999, height: 'auto', top: '15px' }}>
          <FormGroup>
              <FormControlLabel
                sx={{ m: 0 }}
                control={<Checkbox sx={{ p: 1 }} onClick={() => setShowLabel(!showLabel)} />}
                label='Hiển thị số thứ tự đoạn sông'
              />
            </FormGroup>
            <MapLegendNuocNhan onChange={handleConsTypeChange} />
          </Box>
          <MapDoanSong
            center={mapCenter}
            zoom={mapZoom}
            mapData={selectedRiver}
            selectedKmlFile={selectedRiver ? selectedRiver.phanDoanSong.fileKML : null}
            loading={loading}
            filterDatas={filterData}
            dischargeData={data}
            showLabel={showLabel}
          />
        </Paper>
      </Grid>
      <Grid item xs={12}>
        <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <ToolBar onChange={handleFilterChange} tabId='nnn'/>

          <TableComponent
            columns={columnsTable}
            rows={data}
            id='phan_doan_song'
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box className='group_btn'>
                <CreateWasteForm isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'du-lieu-nguon-thai'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default WasteWaterDetails
