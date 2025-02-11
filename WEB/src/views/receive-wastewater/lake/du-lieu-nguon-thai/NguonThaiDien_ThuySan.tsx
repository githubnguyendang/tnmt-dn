import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Checkbox, FormControlLabel, FormGroup, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import DeleteData from 'src/@core/components/delete-data'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'
import ThaiThuySanForm from './form/NguoiThaiThuySanForm'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

const NguonThaiThuySan = () => {
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
          Chiều dài <br /> đoạn sông <br /> (ha)
        </Box>
      ),
      rowspan: 2,
      align: 'left',
      minWidth: 100,
      elm: (row: any) => <span>{row.phanDoanSong.chieuDai}</span>
    },
    {
      id: 'dienTichThuySan',
      label: (
        <Box>
          Diện tích thủy sản
          <br /> (ha)
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
          TẢI LƯỢNG Ô NHIỄM (PLU) NGUỒN THẢI DIỆN (THỦY SẢN) <br />
          (g/ha/ngày)
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ctThuySanBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctThuySanCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctThuySanAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctThuySanTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctThuySanTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctThuySanTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctThuySanColiform',
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
          TẢI LƯỢNG THÔNG SỐ CHẤT LƯỢNG NƯỚC CÓ TRONG NGUỒN THẢI DIỆN (TRỒNG LÚA)
          <br /> Lt_dien_ThuySan
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'ltThuySanBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltThuySanCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltThuySanAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltThuySanTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltThuySanTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltThuySanTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltThuySanColiform',
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
      await getData('DuLieuNguonNuocThaiThuySan/danh-sach')
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
              <ExportTableToExcel tableId='du-lieu-nguon-thai-gia-cam' filename='dulieuthaigiacam.csv' />
            </Grid>
            <Grid item>
              <ThaiThuySanForm isEdit={false} setPostSuccess={handlePostSuccess} />
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
                <ThaiThuySanForm isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'du-lieu-nguon-thai'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default NguonThaiThuySan
