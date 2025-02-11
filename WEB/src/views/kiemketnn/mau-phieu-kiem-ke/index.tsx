import {
  Grid,
  Paper,
  Typography
} from '@mui/material'
import Header from '../header'

const Mauphieukiemkeview= () => {

  return (
    <Paper sx={{ p: 8 }} >
      <Header />

      <Grid item md={12} xs={12} textAlign={'center'} textTransform={'uppercase'}>
        <Typography className='font-weight-bold ' variant='h6'>
          CÁC MẪU PHIẾU ĐIỀU TRA
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          THỰC HIỆN KIỂM KÊ TÀI NGUYÊN NƯỚC
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          (Thực hiện theo công văn số 4464/BTNMT-TNN ngày 16/6/2023 về việc hướng dẫn kiểm kê TNN được phê duyệt tại
          tại quyết định số 1383/QĐ-TTg)
        </Typography>
      </Grid>
      <Grid item md={12} xs={12} pt={3}>
      <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 17 : Phiếu điều tra tổng hợp hiện trạng khai thác, sử dụng nước mặt 
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 18 : Phiếu điều tra chi tiết hiện trạng khai thác, sử dụng nước mặt 
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 19 : Phiếu điều tra tổng hợp hiện trạng khai thác, sử dụng nước dưới đất 
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 20: Phiếu điều tra chi tiết hiện trạng khai thác, sử dụng nước dưới đất
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 21 : Phiếu điều tra tổng hợp hiện trạng xả nước thải vào nguồn nước
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 22 : Phiếu điều tra chi tiết hiện trạng xả nước thải vào nguồn nước
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 23 : Tổng hợp hiện trạng khai thác sử dụng nước
        </Typography>
        <Typography pt={1} pb={2} className='font-weight-bold ' variant='h6'>
          Biểu mẫu số 24 : Tổng hợp hiện trạng xả nước thải vào nguồn nước
        </Typography>
      </Grid>
      
    </Paper>
  )
}
export default Mauphieukiemkeview
