//React Imports
import React, { useEffect } from 'react'
import { useState } from 'react'

//MUI Imports
//import { Box, Paper, FormGroup, FormControlLabel, Checkbox } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'

//import dynamic from 'next/dynamic'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false })

// eslint-disable-next-line react-hooks/rules-of-hooks
const KhaNangTiepNhanNuocThaiAo = () => {
  //Init columnTable

  // const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  // const [mapZoom, setMapZoom] = useState(9)
  // const [showLabel, setShowLabel] = useState(false)
  function roundToTwoDecimalPlaces(num: number): number {
    return parseFloat(num.toFixed(2))
  }

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT' },
    {
      id: 'tenCT',
      label: 'Tên công trình',
      align: 'left',
      minWidth: 200,
      elm: (row: any) => <span>{row.cT_ThongTin.tenCT}</span>
    },
    {
      id: '#',
      label: 'Vị trí',
      align: 'left',
      minWidth: 200,
      elm: (row: any) => <span>{row.cT_ThongTin.viTriCT}</span>
    },

    {
      id: '#',
      label: 'Thông số kỹ thuật',
      align: 'left',
      children: [
        {
          id: 'dienTichLuuVuc',
          label: <>Diện tích <br/> lưu vực (km2)</>,
          align: 'left',
          minWidth: 150,
          elm: (row: any) => <span>{row.cT_ThongTin.thongso.dienTichLuuVuc}</span>
        },
        {
          id: '#',
          label: 'F tưới	',
          children: [
            {
              id: 'ftuoi1',
              label: '',
              align: 'left'
            },
            {
              id: 'ftuoi2',
              label: '',
              align: 'left'
            }
          ]
        },
        {
          id: '#',
          label: 'W trữ',
          children: [
            {
              id: 'wtru1',
              label: '',
              align: 'left'
            },
            {
              id: 'wtru2',
              label: '',
              align: 'left'
            }
          ]
        },
        {
          id: 'tranXaLu',
          label: 'Tràn xả lũ',
          align: 'left'
        }
      ]
    },
    {
      id: 'vh',
      label: 'Vh(m3)',
      align: 'left',
      minWidth: 100
    },
    {
      id: 'fs',
      label: 'Hệ số Fs',
      align: 'left',
      minWidth: 100
    },
    {
      id: '#',
      label: 'KẾT QUẢ PHÂN TÍCH THÔNG SỐ CHẤT LƯỢNG NƯỚC MẶT(Cnn)',
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
              Tổng <br /> coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left'
        }
      ]
    },
    {
      id: '#',
      label: ' GIÁ TRỊ GIỚI HẠN THÔNG SỐ CHẤT LƯỢNG NƯỚC MẶT HỒ CHỨA THEO QCVN08/2023 Cqc (mg/l)	',
      align: 'left',
      children: [
        {
          id: 'cghBOD',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cghCOD',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cghAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cghTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cghTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cghTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cghColiform',
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
      id: '#',
      label: 'KHẢ NĂNG TIẾP NHẬN NƯỚC THẢI, SỨC CHỊU TẢI CỦA HỒ CHỨA Mtn (kg)',
      align: 'left',
      children: [
        {
          id: 'ltnBod',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnBOD)
        },
        {
          id: 'ltnCod',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnCOD)
        },
        {
          id: 'ltnAmoni',
          label: (
            <Box>
              Amoni <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnAmoni)
        },
        {
          id: 'ltnTongN',
          label: (
            <Box>
              Tổng N <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnTongN)
        },
        {
          id: 'ltnTongP',
          label: (
            <Box>
              Tổng P <br />
              (mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnTongP)
        },
        {
          id: 'ltnTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnTSS)
        },
        {
          id: 'ltnColiform',
          label: (
            <Box>
              Tổng  <br /> Coliform
              <br /> (MPN/100ml)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnColiform)
        }
      ]
    },
    {
      id: 'ghiChu',
      label: 'Ghi chú',

      align: 'left'
    }
  ]

  const [mapCenter] = useState([15.012172, 108.676488])
  const [mapZoom] = useState(9)
  const [data, setData] = useState([])
  const [loading, setLoading] = useState(false)

  useEffect(() => {
    async function getDataReport1() {
      setLoading(true)
      await getData('ThongTinAoHo/danh-sach')
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
  }, [])

  // const zoomConstruction = (coords: any) => {
  //   setMapCenter(coords)
  //   setMapZoom(13)
  // }
  // const handleConsTypeChange = (data: any) => {
  //   setInitConstype(data);
  // };

  return (
    <Grid container spacing={2}>
      <Grid xs={12} md={12} sx={{ height: '55vh', overflow: 'hidden' }}>
      <Map center={mapCenter} zoom={mapZoom} lakeData={data} loading={false} />
      </Grid>
      <Grid xs={12} md={12}>
        <Grid className='_text_center'>
          <Typography className='font-weight-bold' sx={{ mt: 3 }} variant='h6'>
            KHẢ NĂNG TIẾP NHẬN NƯỚC THẢI, SỨC CHỊU TẢI CỦA AO,HỒ CHỨA
          </Typography>
        </Grid>
        <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <TableComponent columns={columnsTable} rows={data} loading={loading} pagination />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default KhaNangTiepNhanNuocThaiAo
