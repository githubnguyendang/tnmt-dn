import Paper from '@mui/material/Paper'
import { Grid, Typography, Box, Radio, FormControlLabel } from '@mui/material'
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'

import { getData } from 'src/api/axios'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import dayjs from 'dayjs'
import TableComponent, { TableColumn } from 'src/@core/components/table'

import DeleteData from 'src/@core/components/delete-data'
import ToolBar from './toolbar'
import { red } from '@mui/material/colors'
import viewDetail from '../viewDetail'

const HinhTheThoiTietGayMuaSongVe = () => {
  const [data, setData] = useState<any[]>([])

  const [loading, setLoading] = useState(false)
  const [selectedYear, setSelectedYear] = useState<number>(new Date().getFullYear())

  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }

  useEffect(() => {
    async function getDataHTTT() {
      setLoading(true)

      //API de lay du lieu tu sql: 'HTTT/danh-sach'
      await getData('HTTT/danh-sach')
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

    getDataHTTT()
  }, [postSuccess])

  const columnsTable: TableColumn[] = [
    {
      id: 'stt',
      label: 'STT'
    },
    {
      //Id là trường dữ liệu lưu trong csdl
      id: 'nam',
      label: 'Năm',
      align: 'left',
      minWidth: 100
    },
    {
      //Id là trường dữ liệu lưu trong csdl
      id: 'thang',
      label: 'Tháng',
      align: 'left',
      minWidth: 100
    },
    {
      //Id là trường dữ liệu lưu trong csdl
      id: 'ngay',
      label: 'Ngày',
      align: 'left',
      minWidth: 100
    },
    {
      //Id là trường dữ liệu lưu trong csdl
      id: 'gio',
      label: 'Giờ',
      align: 'left',
      minWidth: 100
    },
    {
      //Id là trường dữ liệu lưu trong csdl
      id: 'phanCapLu',
      label: 'Phân cấp lũ',
      align: 'left'
    },
    {
      id: 'sTTLu',
      label: (
        <span>
          {' '}
          Số thứ tự <br /> trận lũ <br /> trong năm
        </span>
      ),
      align: 'left'
    },
    {
      id: 'nhanDangLu',
      label: 'Nhận dạng lũ',
      align: 'left'
    },

    {
      id: 'hinhTheThoiTiet',
      label: 'Hình thế thời tiết',
      align: 'left'
    },
    {
      id: 'ngayHinhThanh',
      label: 'Ngày hình thành',
      align: 'left'
    },
    {
      id: 'tamBaoVungAnhHuongManh',
      label: (
        <span>
          Tâm bão <br /> vùng ảnh hưởng mạnh <br />{' '}
        </span>
      ),
      align: 'left'
    },
    {
      id: 'ngayDoBo',
      label: (
        <span>
          Ngày đổ bộ <br /> / tác động trực tiếp <br />{' '}
        </span>
      ),

      align: 'left'
    },
    {
      id: 'viTriDoBo',
      label: (
        <span>
          Vị trí đổ bộ <br /> / tác động trực tiếp <br />{' '}
        </span>
      ),

      align: 'left'
    },
    {
      id: 'capDoBao',
      label: (
        <span>
          Cấp độ bão
          <br /> / độ mạnh <br />{' '}
        </span>
      ),

      align: 'left'
    },
    {
      id: 'tongLuongMua',
      label: (
        <span>
          Tổng <br />
          lượng mưa <br /> (mm){' '}
        </span>
      ),
      align: 'left'
    },
    {
      id: 'chiTietTranLu',
      label: 'Chi tiết trận lũ',
      align: 'left'
    },
    {
      id: '',
      label: 'H Max',
      elm: () => viewDetail(),
      align: 'left'
    },
    {
      id: 'ghiChu',
      label: 'Ghi chú',
      align: 'left'
    },
    { align: 'center', id: 'actions', label: 'Thao tác', minWidth: 150 }
  ]

  return (
    <Paper sx={{ p: 8 }}>
      <Grid className='_text_center' color={red}>
        <Typography className='font-weight-bold ' variant='h6'>
          CÁC ĐẶC TRƯNG HÌNH THẾ THỜI TIẾT GÂY MƯA LỚN TRÊN LƯU VỰC SÔNG VỆ
        </Typography>
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
      </Grid>
      <Grid className='_text_left'>
        <FormControlLabel value='female' control={<Radio />} label='(A) Bão hoặc ATNĐ hoặc áp thấp' />
        <FormControlLabel value='female' control={<Radio />} label='(B) Bão hoặc ATNĐ + KKL' />
        <FormControlLabel value='female' control={<Radio />} label='(C) Giải HTNĐ + KKL' />
        <FormControlLabel value='female' control={<Radio />} label='(D) KKL + đới gió đông' />
        <FormControlLabel value='female' control={<Radio />} label='(E) Tổ hợp hình thế thời tiết khác ' />
        <FormControlLabel value='female' control={<Radio />} label='(F) Tổ hợp các hình thế trên ' />
      </Grid>

      {/* <CreateReport2 isEdit={false} setPostSuccess={handlePostSuccess}/> */}
      {loading ? (
        <BoxLoading />
      ) : (
        <Grid className='_text_center' sx={{ mt: 3 }}>
          <ToolBar onExport={{ data: data, column: columnsTable }} />
          <TableComponent
            columns={columnsTable}
            rows={data}
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box>
                <DeleteData url={'HTTT'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Grid>
      )}
    </Paper>
  )
}

export default HinhTheThoiTietGayMuaSongVe

