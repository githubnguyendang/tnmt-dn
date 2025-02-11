import Paper from '@mui/material/Paper'
import { Box, Grid, Typography } from '@mui/material'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import Header from '../../header'
import Footer from '../../footer'
import { getData } from 'src/api/axios'
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import dayjs from 'dayjs'
import DeleteData from 'src/@core/components/delete-data'
import CreateRainWater from '../../nuoc-mua/form'

const LVSnoitinh = () => {
  const [data, setData] = useState<any[]>([])
  console.log(data)

  const [loading, setLoading] = useState(false)
  const [selectedYear, setSelectedYear] = useState<number>(new Date().getFullYear())

  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  useEffect(() => {
    async function getDataRainWater() {
      setLoading(true)
      await getData(`NM_TongLuong/danh-sach?nam_bao_cao=${selectedYear}`)
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
  }, [postSuccess, selectedYear])

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', rowspan: 2 },
    {
      id: 'tenCT',
      label: 'LVS nội tỉnh',
      align: 'left',
      rowspan: 2,
      elm: (row: any) => <Typography className='f_14'>{row.luuVucSong?.tenLVS}</Typography>
    },
    {
      id: 'thuoc_song',
      label: 'Vị trí ',
      align: 'left',
      children: [
        { id: '#3.1', label: 'Xã', align: 'left' },
        { id: '#3.2', label: 'Huyện', align: 'left' }
      ]
    },
    {
      id: 'thuoc_song',
      label: 'Tháng',
      align: 'left',
      children: [
        { id: 'thang1', label: '1', align: 'left' },
        { id: 'thang2', label: '2', align: 'left' },
        { id: 'thang3', label: '3', align: 'left' },
        { id: 'thang4', label: '4', align: 'left' },
        { id: 'thang5', label: '5', align: 'left' },
        { id: 'thang6', label: '6', align: 'left' },
        { id: 'thang7', label: '7', align: 'left' },
        { id: 'thang8', label: '8', align: 'left' },
        { id: 'thang9', label: '9', align: 'left' },
        { id: 'thang10', label: '10', align: 'left' },
        { id: 'thang11', label: '11', align: 'left' },
        { id: 'thang12', label: '12', align: 'left' }
      ]
    },
    {
      id: 'muaLu',
      label: 'Mùa mưa',
      align: 'left',
      rowspan: 2
    },
    {
      id: 'muaKiet',
      label: 'Mùa khô',
      align: 'left',
      rowspan: 2
    },
    {
      id: 'caNam',
      label: 'Cả năm',
      align: 'left',
      rowspan: 2
    },
    { id: 'actions', label: 'Thao tác', rowspan: 2 }
  ]

  return (
    <Paper sx={{ p: 8 }}>
      <Header />

      <Grid className='_text_center'>
        <Typography className='font-weight-bold ' variant='h6'>
          BÁO CÁO
        </Typography>
        <Typography className='font-weight-bold' variant='body1' textTransform={'uppercase'}>
          Kiểm kê tổng lượng dòng chảy theo lưu vực sông nội tỉnh
        </Typography>
        <Typography className='font-weight-bold ' variant='h6'>
          (Kỳ báo cáo:{' '}
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DatePicker
              views={['year']}
              value={dayjs(new Date(selectedYear, 1, 1))}
              onChange={(newVal: any) => setSelectedYear(newVal.year())}
              slotProps={{ textField: { size: 'small', fullWidth: true, required: true } }}
              sx={{ width: '100px' }}
            />
          </LocalizationProvider>
          )
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

export default LVSnoitinh
