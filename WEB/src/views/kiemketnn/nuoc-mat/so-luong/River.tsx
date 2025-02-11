import Paper from '@mui/material/Paper'
import { Grid, Typography, Box } from '@mui/material'
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import Header from '../../header'
import Footer from '../../footer'
import { getData } from 'src/api/axios'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import dayjs from 'dayjs'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import RiverToolBar from './toolbar'
import CreateRiver from './CreateRiver'
import DeleteData from 'src/@core/components/delete-data'

const River = () => {
  const [data, setData] = useState<any[]>([])

  const [loading, setLoading] = useState(false)
  const [selectedYear, setSelectedYear] = useState<number>(new Date().getFullYear())

  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  useEffect(() => {
    async function getDataRiver() {
      setLoading(true)
      await getData('NM_SoLuong/danh-sach/song-suoi')
        .then(data => {
          setData(data)
          console.log(data)
        })
        .catch(error => {
          console.log(error)
        })
        .finally(() => {
          setLoading(false)
        })
    }

    getDataRiver()
  }, [postSuccess])

  const columnsTable: TableColumn[] = [
    {
      id: 'stt',
      label: 'STT',
      rowspan: 3
    },
    {
      id: '#',
      label: 'Mã sông',
      align: 'left',
      children: [
        {
          id: 'maSong',
          label: '01',
          align: 'left',
          minWidth: 20
        },
        {
          id: '#',
          label: '02',
          align: 'left',
          minWidth: 40
        },
        {
          id: '#',
          label: '03',
          align: 'left',
          minWidth: 40
        },
        {
          id: '#',
          label: '04',
          align: 'left',
          minWidth: 40
        },
        {
          id: '#',
          label: '05',
          align: 'left',
          minWidth: 40
        },
        {
          id: '#',
          label: '06',
          align: 'left',
          minWidth: 40
        }
      ]
     },
    {
      id: 'tenSong',
      label: 'Tên sông',
      align: 'left'
    },
    {
      id: 'chayRa',
      label: 'Chảy ra',
      align: 'left'
    },
    {
      id: 'chieuDai',
      label: 'Chiều dài(km)',
      align: 'left'
    },
    {
      id: 'chieuDaiThuocTinh_ThanhPho',
    
      label: (<span>Chiều dài thuộc<br />tỉnh, thành phố (km)</span>),
        
      align: 'left'
    },
    {
      id: '#',
      label: 'Vị trí đầu sông',
      align: 'left',
      children: [
        {
          id: 'dauSongX',
          label: 'Tọa độ X',
          align: 'left',
          minWidth: 100
        },
        {
          id: 'dauSongY',
          label: 'Tọa độ Y',
          align: 'left',
          minWidth: 100
        },
        {
          id: 'dauSongXaHuyenTinh',
          label: 'Xã,Huyện',
          align: 'left',
          minWidth: 150
        }
      ]
    },
    {
      id: '#',
      label: 'Vị trí cuối sông',
      align: 'left',
      children: [
        {
          id: 'cuoiSongX',
          label: 'Tọa độ X',
          align: 'left',
          minWidth: 100
        },
        {
          id: 'cuoiSongY',
          label: 'Tọa độ Y',
          align: 'left',
          minWidth: 100
        },
        {
          id: 'cuoiSongXaHuyenTinh',
          label: 'Xã, Huyện',
          align: 'left',
          minWidth: 100
        }
      ]
    },
    {
      id: 'ghiChu',
      label: 'Ghi chú',
      align: 'left'
    },
    { id: 'actions', label: 'Thao tác', minWidth:100, rowspan: 3 }
  ]

  return (
    <Paper sx={{ p: 8 }}>
      <Header />

      <Grid className='_text_center'>
        <Typography className='font-weight-bold ' variant='h6'>
          BÁO CÁO
        </Typography>
        <Typography className='font-weight-bold ' variant='h6'>
          KIỂM KÊ SỐ LƯỢNG NGUỒN NƯỚC MẶT LÀ CÁC SÔNG, SUỐI, KÊNH, RẠCH TỈNH QUẢNG NGÃI
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
      {/* <CreateReport2 isEdit={false} setPostSuccess={handlePostSuccess}/> */}
      {loading ? (
        <BoxLoading />
      ) : (
        <Grid className='_text_center' sx={{ mt: 3 }}>
          <RiverToolBar onExport={{ data: data, column: columnsTable }} />
          <TableComponent
            columns={columnsTable}
            rows={data}
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box>
                <CreateRiver isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'NM_SoLuong/song-suoi'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Grid>
      )}

      <Footer />
    </Paper>
  )
}

export default River
