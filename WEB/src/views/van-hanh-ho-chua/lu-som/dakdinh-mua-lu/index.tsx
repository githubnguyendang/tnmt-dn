import { Grid, Typography, Paper } from '@mui/material'
import HienTrangVanHanhHo from './hientrangvanhanh'
import PhuongAnDieuHanhHo from './phuongandieuhanh'
import BieuDoMucNuoc from './bieudo'

const series = [
  {
    data: [1, 2, 3, 4, 5, 6, 7, 8]
  }
]

const year = [
  {
    data: [1, 2, 3, 4, 5, 6, 7, 8]
  }
]

const DakdrinhhMuaLu = () => {
  return (
    <Grid container spacing={4} rowSpacing={5}>
      <Grid item sm={12} md={7}>
        <HienTrangVanHanhHo />
      </Grid>
      <Grid item xs={5} md={5}>
        <Paper sx={{ height: '100%' }}>
          <Typography className='title_header' sx={{ py: 4 }}>
            {' '}
            QUY ĐỊNH VẬN HÀNH HỒ CHỨA ĐĂKĐRINH (MNDBT= 410)
          </Typography>
          <img src='/images/hodakdrinh_vanhanh.png' alt='Description' style={{ width: '100%', maxHeight: '100%' }} />
        </Paper>
      </Grid>
      <Grid item xs={7} md={7}>
        <BieuDoMucNuoc series={series} year={year} color={undefined} />
      </Grid>
      <Grid item xs={5} md={5}>
        <PhuongAnDieuHanhHo />
      </Grid>
    </Grid>
  )
}

export default DakdrinhhMuaLu
