import Paper from '@mui/material/Paper'
import { Box, Grid, IconButton, Typography } from '@mui/material'
import { useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import Header from '../../header'
import Footer from '../../footer'
import { Delete, Edit } from '@mui/icons-material'

const Chuyennuocluuvuc = () => {
  const [data] = useState<any[]>([])
  const [loading] = useState(false)

  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', rowspan: 2 },
    {
      id: 'tenCT',
      label: 'Lưu vực sông',
      align: 'left',
      rowspan: 2
    },
    {
      id: 'nguonnuoc_kt',
      label: 'Tên công trình chuyển nước',
      align: 'left',
      rowspan: 2
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
      id: 'nguonnuoc_kt',
      label: 'LV sông nhận nước',
      align: 'left',
      rowspan: 2
    },
    {
      id: 'thuoc_song',
      label: 'Tổng lượng nước chuyển (triệu m3)',
      align: 'left',
      children: [
        {
          id: 'nguonnuoc_kt',
          label: 'TB mùa lũ',
          align: 'left',
          rowspan: 2
        },
        {
          id: 'nguonnuoc_kt',
          label: 'TB mùa cạn',
          align: 'left',
          rowspan: 2
        },
        {
          id: 'nguonnuoc_kt',
          label: 'TB cả năm',
          align: 'left',
          rowspan: 2
        },
      ]
    },
 
    { id: 'actions', label: 'Ghi chú', rowspan: 2 }
  ]

  return (
    <Paper sx={{ p: 8 }}>
      <Header />

      <Grid className='_text_center'>
        <Typography className='font-weight-bold ' variant='h6'>
          BÁO CÁO
        </Typography>
        <Typography className='font-weight-bold' variant='body1' textTransform={'uppercase'}>
          Kiểm kê tổng lượng nước chuyển giữa các lưu vực sông 
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
            actions={() => (
              <Box className='group_btn'>
                <IconButton>
                  <Edit />
                </IconButton>
                <IconButton>
                  <Delete />
                </IconButton>
              </Box>
            )}
          />
        </Grid>
      )}

      <Footer />
    </Paper>
  )
}

export default Chuyennuocluuvuc
