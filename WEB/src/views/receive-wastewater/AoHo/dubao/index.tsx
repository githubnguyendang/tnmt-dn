//React Imports
import React, { useEffect } from 'react'
import { useState } from 'react'

//MUI Imports
//import { Box, Paper, FormGroup, FormControlLabel, Checkbox } from '@mui/material'


//import dynamic from 'next/dynamic'
import dynamic from 'next/dynamic'
import { getData } from 'src/api/axios'
import { Box, Grid, Paper, Typography } from '@mui/material'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import LakeForeCastTForm from './forecastForm'

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false })

// eslint-disable-next-line react-hooks/rules-of-hooks
const LakeForeCast = () => {
  //Init columnTable

  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }

  function roundToTwoDecimalPlaces(num: number): number {
    return parseFloat(num?.toFixed(2))
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
      id: 'thongSoCLNDuBao',
      label: ' GIÁ TRỊ GIỚI HẠN THÔNG SỐ CHẤT LƯỢNG NƯỚC MẶT HỒ CHỨA THEO QCVN08/2023 Cqc (mg/l)	',
      align: 'left',
      children: [
        {
          id: 'bod',
          label: (
            <Box>
              BOD5 <br />
              (mg/l)
            </Box>
          ),
          elm: (row: any) => <span>{row.thongSoCLNDuBao.bod}</span>,
          align: 'left'
        },
        {
          id: 'cod',
          label: (
            <Box>
              COD <br />
              (mg/l)
            </Box>
          ),
          elm: (row: any) => <span>{row.thongSoCLNDuBao.cod}</span>,
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
          elm: (row: any) => <span>{row.thongSoCLNDuBao.amoni}</span>,
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
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tongN}</span>,
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
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tongP}</span>,
          align: 'left'
        },
        {
          id: 'cghTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tss}</span>,
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
          elm: (row: any) => <span>{row.thongSoCLNDuBao.tongColiform}</span>,
          align: 'left'
        }
      ]
    },
    {
      id: '#',
      label: 'DỰ BÁO KHẢ NĂNG TIẾP NHẬN NƯỚC THẢI, SỨC CHỊU TẢI CỦA HỒ CHỨA Mtn (kg)',
      align: 'left',
      children: [
        {
          id: 'mtnBod',
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
          id: 'mtnCod',
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
          id: 'mtnAmoni',
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
          id: 'mtnTongN',
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
          id: 'mtnTongP',
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
          id: 'mtnTSS',
          label: (
            <Box>
              Tổng <br /> chất rắn <br /> lơ lửng <br /> TSS(mg/l)
            </Box>
          ),
          align: 'left',
          elm: (row: any) => roundToTwoDecimalPlaces(row.mtnTSS)
        },
        {
          id: 'mtnColiform',
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
  
  ]

  const [mapCenter] = useState([15.012172, 108.676488])
  const [mapZoom] = useState(9)
  const [data, setData] = useState([])
  console.log(data);
  
  const [loading, setLoading] = useState(false)

  useEffect(() => {
    async function getDataReport1() {
      setLoading(true)
      await getData('DuBaoKNTNNuocAo/danh-sach')
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

  // const zoomConstruction = (coords: any) => {
  //   setMapCenter(coords)
  //   setMapZoom(13)
  // }
  // const handleConsTypeChange = (data: any) => {
  //   setInitConstype(data);
  // };

  return (
    <>
     <Grid>
      <Typography textAlign={'center'} variant='h6'>
        Tính Dự Báo Khả Năng Tiếp Nhận Nước Thải
      </Typography>
    </Grid>
    <Grid container spacing={5}>
      <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
      <LakeForeCastTForm setPostSuccess={handlePostSuccess}/>
      </Grid>
      <Grid item xs={12} md={8} sm={12} sx={{ my: 2 }}>
        <Map center={mapCenter} zoom={mapZoom} mapData={null} />
      </Grid>
    </Grid>
      <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <TableComponent columns={columnsTable} rows={data} loading={loading} pagination />
      </Paper>

    </>
  )
}

export default LakeForeCast
