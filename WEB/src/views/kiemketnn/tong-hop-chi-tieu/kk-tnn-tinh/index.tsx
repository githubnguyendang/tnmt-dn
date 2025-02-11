import Paper from '@mui/material/Paper'
import { Box, Grid, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from '@mui/material'
import Header from '../../header'
import Footer from '../../footer'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import { getData } from 'src/api/axios'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'

const KiemKeTNNTinh = () => {
  const [dynamicData, setDynamicData] = useState<any[]>([])
  console.log(dynamicData)

  const [loading, setLoading] = useState(false)

  // const [dynamicData] = useState(fixedData);
  // const [loading] = useState(false);

  useEffect(() => {
    async function getDataExploitWater() {
      setLoading(true)
      await getData(`ChiTieuLVSTraKhuc/danhsach`)
        .then(data => {
          setDynamicData(data)
        })
        .catch(error => {
          console.log(error)
        })
        .finally(() => {
          setLoading(false)
        })
    }

    getDataExploitWater()
  }, [])

  return (
    <Paper sx={{ p: 8 }}>
      <Header />

      <Grid className='_text_center'>
        <Typography className='font-weight-bold' variant='body1' textTransform={'uppercase'}>
          TỔNG HỢP CÁC CHỈ TIÊU KIỂM KÊ TÀI NGUYÊN NƯỚC <br />
          CỦA TỈNH, THÀNH PHỐ
        </Typography>
      </Grid>

      {loading ? (
        <BoxLoading />
      ) : (
        <TableContainer component={Paper}>
          <Box sx={{ width: 200, py: 2 }}>
            <ExportTableToExcel tableId={'tonghopchitieulvstrakhuc'} filename={'tonghopchitieulvstrakhuc'} />
          </Box>
          <Table id='tonghopchitieulvstrakhuc'>
            <TableHead className='tableHead'>
              <TableRow>
                <TableCell align='center'>STT</TableCell>
                <TableCell align='center'>Nhóm,tên chỉ tiêu</TableCell>
                <TableCell align='center'>Đơn vị tính</TableCell>
                <TableCell align='center'>Kết quả</TableCell>
                <TableCell align='center'>Ghi chú</TableCell>
              </TableRow>
              <TableRow>
                <TableCell align='center'>(1)</TableCell>
                <TableCell align='center'>(2)</TableCell>
                <TableCell align='center'>(3)</TableCell>
                <TableCell align='center'>(4)</TableCell>
                <TableCell align='center'>(5)</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {dynamicData.map((row, index) => (
                <TableRow key={index}>
                  <TableCell align='center'>{row.stt}</TableCell>
                  <TableCell>{row.tenChiTieu}</TableCell>
                  <TableCell align='center'>{row.donViTinh}</TableCell>
                  <TableCell align='center'>{row.ketqua}</TableCell>
                  <TableCell align='center'>{row.ghiChu}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      )}

      <Footer />
    </Paper>
  )
}

export default KiemKeTNNTinh
