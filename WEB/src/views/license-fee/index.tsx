import { useState, useEffect } from 'react'
import { Grid, Typography, Paper, Box, Toolbar } from '@mui/material'
import { formatDate, formatNum } from 'src/@core/components/formater'
import FormLicenseFee from 'src/views/license-fee/form'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import ShowFilePDF from 'src/@core/components/show-file-pdf'
import DeleteData from 'src/@core/components/delete-data'
import { getData } from 'src/api/axios'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'
import { DatePicker } from '@mui/x-date-pickers/DatePicker'
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider'
import dayjs from 'dayjs'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'

interface LicenseFeeProps {
  path: string
}

const LicenseFee = (props: LicenseFeeProps) => {
  const { path } = props
  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  const [resData, setResData] = useState([])
  const [loading, setLoading] = useState(false)
  const [endYear, setEndYear] = useState<Date | null>(new Date())
  const [startYear, setStartYear] = useState<Date | null>(
    new Date(`${new Date().getDate()}-${new Date().getMonth() + 1}-${new Date().getFullYear() - 5}`)
  )

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', minWidth: 90 },
    {
      id: 'soQDTCQ',
      label: 'Quyết định cấp quyền',
      minWidth: 250,
      pinned: 'left',
      elm: (row: any) => <ShowFilePDF name={row?.soQDTCQ} src={row?.filePDF} />
    },
    {
      id: 'ngayKy',
      label: 'Ngày ký',
      minWidth: 180,
      elm: (row: any) => formatDate(row.ngayKy)
    },
    {
      id: 'qd_bosung',
      label: 'Quyết định bổ sung',
      minWidth: 180,
      elm: (data: any) => <ShowFilePDF name={data.qd_bosung?.soQDTCQ} src={data.qd_bosung?.filePDF} />
    },
    {
      id: 'tongTienCQ',
      label: 'Tổng số tiền cấp quyền(VNĐ)',
      elm: (data: any) => formatNum(data.tongTienCQ)
    },
    { id: 'ghiChu', minWidth: 280, label: 'Ghi chú' },

    //license
    {
      id: 'so_gp',
      label: 'Giấy phép'
    },

    //construction
    {
      id: 'ten_ct',
      label: 'Công trình',
      minWidth: 150
    },

    //Action
    {
      id: 'actions',
      label: 'Thao tác',
      pinned: 'right'
    }
  ]

  useEffect(() => {
    const getDataLicenseFee = async () => {
      setLoading(true)
      try {
        const data = await getData('tien-cap-quyen/danh-sach', {
          startYear: startYear ? startYear.getFullYear() : null,
          endYear: endYear ? endYear.getFullYear() : null,
          coquan_cp: path === 'bo-cap' ? 'bo-cap' : 'tinh-cap'
        })
        setResData(data)
      } catch (error) {
        setResData([])
      } finally {
        setLoading(false)
      }
    }
    getDataLicenseFee()
  }, [path, postSuccess, startYear, endYear])

  // Calculate the total of resData.totalMoney
  const totalMoneySum = resData.reduce((sum, item: any) => sum + (item.tongTienCQ || 0), 0)

  return (
    <Grid container spacing={3}>
      <Grid item xs={12} sm={12} md={12} className='text-center'>
        <Typography className='font-weight-bold' variant='h6'>
          THỐNG KÊ
        </Typography>
        {path === 'bo-cap' ? (
          <Typography className='font-weight-bold' variant='h6'>
            KẾT QUẢ THU TIỀN CẤP QUYỀN KHAI THÁC SỬ DỤNG NƯỚC CỦA CÁC CÔNG TRÌNH DO BỘ CẤP PHÉP
          </Typography>
        ) : path === 'tinh-cap' ? (
          <Typography className='font-weight-bold' variant='h6'>
            KẾT QUẢ THU TIỀN CẤP QUYỀN KHAI THÁC SỬ DỤNG NƯỚC CỦA CÁC CÔNG TRÌNH DO TỈNH CẤP PHÉP
          </Typography>
        ) : null}
      </Grid>
      <Grid item xs={12} sm={12} md={12}>
        <Typography>
          Tổng số tiền cấp quyền{' '}
          {startYear?.getFullYear() === endYear?.getFullYear()
            ? `năm ${startYear?.getFullYear()}`
            : `từ năm ${startYear?.getFullYear()} đến năm ${endYear?.getFullYear()}`}
          : &nbsp;
          {formatNum(totalMoneySum)}
        </Typography>
      </Grid>
      <Grid item xs={12} sm={12} md={12}>
        <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <Toolbar variant='dense'>
            <Grid container spacing={2} justifyContent={'end'}>
              <Grid item>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DatePicker
                    views={['year']}
                    label='Từ năm'
                    value={dayjs(startYear)}
                    onChange={(newValue: any) => {
                      setStartYear(newValue ? newValue.toDate() : null)
                    }}
                    slotProps={{
                      textField: {
                        size: 'small',
                        fullWidth: true
                      }
                    }}
                    format='YYYY'
                  />
                </LocalizationProvider>
              </Grid>
              <Grid item>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DatePicker
                    views={['year']}
                    label='Đến năm'
                    value={dayjs(endYear)}
                    onChange={(newValue: any) => {
                      setEndYear(newValue ? newValue.toDate() : null)
                    }}
                    slotProps={{
                      textField: {
                        size: 'small',
                        fullWidth: true
                      }
                    }}
                    format='YYYY'
                  />
                </LocalizationProvider>
              </Grid>
              <Grid item>
                <ExportTableToExcel tableId={'licensefee-data'} filename={'TienCapQuyen'} />
              </Grid>
              <Grid item>
                <FormLicenseFee setPostSuccess={handlePostSuccess} isEdit={false} />
              </Grid>
            </Grid>
          </Toolbar>
          <TableComponent
            id='licensefee-data'
            columns={columnsTable}
            rows={resData}
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box className='group_btn'>
                <FormLicenseFee isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'tien-cap-quyen'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default LicenseFee
