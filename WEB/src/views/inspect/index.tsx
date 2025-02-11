import { useState, useEffect } from 'react'
import { Grid, Typography, Paper, Box, Toolbar } from '@mui/material'
import { formatDate, formatNum } from 'src/@core/components/formater'
import FormInspect from 'src/views/inspect/form'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import ShowFilePDF from 'src/@core/components/show-file-pdf'
import DeleteData from 'src/@core/components/delete-data'
import { getData } from 'src/api/axios'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'


const Inspect = () => {
  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  const [resData, setResData] = useState([])
  const [loading, setLoading] = useState(false)

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', minWidth: 90 },
    {
      id: 'soVanBan',
      label: 'Số văn bản',
      minWidth: 250,
      pinned: 'left',
      elm: (row: any) => <ShowFilePDF name={row?.soQDTCQ} src={row?.filePDF} />
    },
    {
      id: 'dot',
      label: 'Đợt thanh tra',
      minWidth: 180
    },
    {
      id: 'donVi',
      label: 'Đơn vị thanh tra',
      minWidth: 180
    },
    {
      id: 'thoiGan',
      label: 'Thời gian thanh tra',
      minWidth: 180,
      elm: (row: any) => formatDate(row.ngayKy)
    },
    {
      id: 'tienPhat',
      label: 'Tổng số tiền phạt vi phạm hành chính',
      elm: (data: any) => formatNum(data.tienPhat)
    },
    { id: 'ghiChu', minWidth: 280, label: 'Ghi chú' },

    //Action
    {
      id: 'actions',
      label: 'Thao tác',
      pinned: 'right'
    }
  ]

  useEffect(() => {
    const getDataInspect = async () => {
      setLoading(true)
      try {
        const data = await getData('thanh-tra-kiem-tra/danh-sach')
        setResData(data)
      } catch (error) {
        setResData([])
      } finally {
        setLoading(false)
      }
    }
    getDataInspect()
  }, [ postSuccess])

  return (
    <Grid container spacing={3}>
      <Grid item xs={12} sm={12} md={12} className='text-center'>
        <Typography className='font-weight-bold' variant='h6'>
          THỐNG KÊ KẾT QUẢ THANH TRA - KIỂM TRA
        </Typography>
      </Grid>
      <Grid item xs={12} sm={12} md={12}>
        <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
          <Toolbar variant='dense'>
            <Grid container spacing={2} justifyContent={'end'}>
              <Grid item>
                <ExportTableToExcel tableId={'Inspect-data'} filename={'ThanhTraKiemTra'} />
              </Grid>
              <Grid item>
                <FormInspect setPostSuccess={handlePostSuccess} isEdit={false} />
              </Grid>
            </Grid>
          </Toolbar>
          <TableComponent
            id='Inspect-data'
            columns={columnsTable}
            rows={resData}
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box className='group_btn'>
                <FormInspect isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                <DeleteData url={'thanh-tra-kiem-tra'} data={row} setPostSuccess={handlePostSuccess} />
              </Box>
            )}
          />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default Inspect
