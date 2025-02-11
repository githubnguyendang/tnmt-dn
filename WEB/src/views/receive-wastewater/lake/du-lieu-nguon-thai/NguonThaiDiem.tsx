import React, { useState, useCallback, useEffect, useRef } from 'react'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Checkbox, FormControlLabel, FormGroup, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { calculateBounds, fetchAndParseKML } from 'src/@core/components/map/utils'
import MapLegendThaiDiem from './MapLegend'
import ThaiDiemForm from './form/NguonThaiDiemForm'
import DeleteData from 'src/@core/components/delete-data'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'

const MapDoanSong = dynamic(() => import('src/@core/components/map/mapdoansong'), { ssr: false })

const NguonThaiDiem = () => {
  const [data, setData] = useState([])
  const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  const [showLabel, setShowLabel] = useState(false)
  const [mapZoom, setMapZoom] = useState(9.8)
  const [selectedRiver, setSelectedRiver] = useState<any>()
  const [loading, setLoading] = useState(false)
  const [filterOptions, setFilterOptions] = useState([])
  const [filterData, setFilterData] = useState([])
  const [industrialZoneKmlFiles, setIndustrialZoneKmlFiles] = useState<string[]>([]);

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
      id: 'nguonThaiCongTrinh',
      label: (
        <Box>
          Nguồn thải
          <br /> công trình XT <br />
        </Box>
      ),
      rowspan: 2,
      align: 'left',
      minWidth: 550
    },
    {
      id: '#',
      label: (
        <Box>
          Tọa độ vị trí <br /> xả thải <br /> của công trình XT
        </Box>
      ),
      align: 'left',
      children: [
        {
          id: 'toaDoX',
          label: (
            <Box>
              Tọa độ <br />X
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'toaDoY',
          label: (
            <Box>
              Tọa độ <br />Y
            </Box>
          ),
          align: 'left'
        }
      ]
    },
    {
      id: 'luuLuongXaThai',
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
          id: 'ctdiemBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ctdiemColiform',
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
          id: 'ltdiemBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'ltdiemColiform',
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
      try {
        const [dataResponse, filterResponse] = await Promise.all([
          getData('DuLieuNguonNuocThaiDiem/danh-sach'),
          getData('NguonThaiDiem/danh-sach')
        ])
        setData(dataResponse)
        setFilterOptions(filterResponse)
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

  const handleConsTypeChange = (selectedTypes: string[]) => {
    const filteredData = filterOptions.filter((item: { [key: string]: any }) =>
      selectedTypes.some((keyword: any) => item['loai']?.toString().toLowerCase().includes(keyword.toLowerCase()))
    );
  
    // Set array of KML files based on selected types
    const kmlFiles = selectedTypes.includes('Khu Công Nghiệp')
      ? ['/kml/doansong/KCN_Point.kml', '/kml/doansong/KCN_Test.kml']
      : [];
  
    setIndustrialZoneKmlFiles(kmlFiles); // Update the state with the new KML files or empty array
    setFilterData(filteredData);
  };

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
            <MapLegendThaiDiem onChange={handleConsTypeChange} />
          </Box>
          <MapDoanSong
            center={mapCenter}
            zoom={mapZoom}
            mapData={selectedRiver}
            selectedKmlFile={selectedRiver ? selectedRiver.phanDoanSong.fileKML : null}
            loading={loading}
            filterData={filterData}
            industrialZoneKmlFiles={industrialZoneKmlFiles}
            dischargeData={data}
            showLabel={showLabel}
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
              <ThaiDiemForm isEdit={false} setPostSuccess={handlePostSuccess} />
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
                <ThaiDiemForm isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'du-lieu-nguon-thai'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default NguonThaiDiem
