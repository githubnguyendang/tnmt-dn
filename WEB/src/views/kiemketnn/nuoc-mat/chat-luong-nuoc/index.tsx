import Paper from '@mui/material/Paper'
import { Box, Grid, Typography } from '@mui/material'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import Header from '../../header'
import Footer from '../../footer'
import { getData } from 'src/api/axios'
import DeleteData from 'src/@core/components/delete-data'
import CreateRainWater from '../../nuoc-mua/form'

const QualitySFWater = () => {
  const [data, setData] = useState<any[]>([])
  const [loading, setLoading] = useState(false)

  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  useEffect(() => {
    async function getDataRainWater() {
      setLoading(true)
      await getData(`NM_ChatLuong/danh-sach`)
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

    getDataRainWater()
  }, [postSuccess])

  const columnsTable: TableColumn[] = [
    {
      id: 'stt',
      label: 'STT'
    },
    {
      id: 'nguonNuoc',
      label: 'Nguồn nước(sông, suối, ao, hồ, đầm,...)',
      align: 'left'
    },
    {
      id: 'dientich_matnuoc',
      label: 'Vị trí hành chính',
      align: 'left',
      children: [
        {
          id: 'xa',
          label: 'Xã',
          align: 'left'
        },
        {
          id: 'huyen',
          label: 'Huyện',
          align: 'left'
        },
        {
          id: '#8',
          label: 'Tỉnh',
          align: 'left'
        }
      ]
    },
    {
      id: 'thuocLVS',
      label: 'Thuộc lưu vực sông',
      align: 'left'
    },
    {
      id: 'gtwqi',
      label: 'Giá trị WQI',
      align: 'left'
    },
    {
      id: 'thoiGian',
      label: 'Thời gian',
      align: 'left'
    },
    { id: 'actions', label: 'Thao tác', rowspan: 3 }
  ]

  return (
    <Paper sx={{ p: 8 }}>
      <Header />

      <Grid className='_text_center'>
        <Typography className='font-weight-bold ' variant='h6'>
          BÁO CÁO
        </Typography>
        <Typography className='font-weight-bold' variant='body1' textTransform={'uppercase'}>
          KIỂM KÊ CHẤT LƯỢNG NGUỒN NƯỚC MẶT
        </Typography>
        <Typography className='font-weight-bold' variant='subtitle2' textTransform={'uppercase'}>
          (Theo chỉ số chất lượng nước tổng hợp wqi)
        </Typography>
      </Grid>
      {loading ? (
        <BoxLoading />
      ) : (
        <Grid className='_text_center' sx={{ mt: 3 }}>
          <TableComponent
            columns={columnsTable}
            rows={data}
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box className='group_btn'>
                <CreateRainWater isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'licensefee'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Grid>
      )}

      <Footer />
    </Paper>
  )
}

export default QualitySFWater
