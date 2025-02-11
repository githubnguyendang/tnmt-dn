import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from '@mui/material'

const HienTrangVanHanhHo = () => {
  const data = [
    { label: 'H Trà Khúc (m)', values: Array(8).fill('') },
    { label: 'Mực nước hồ (H_m)', values: Array(8).fill('') },
    { label: 'Q đến hồ (m3/s)', values: Array(8).fill('') },
    { label: 'Q xả mặt (m3/s)', values: Array(8).fill('') },
    { label: 'Q xả đáy (m3/s)', values: Array(8).fill('') },
    { label: 'Tổng Q xả (m3/s)', values: Array(8).fill('') },
    { label: 'Số cửa xả đáy', values: Array(8).fill('') },
    { label: 'Số cửa xả mặt', values: Array(8).fill('') }
  ]

  return (
    <Paper sx={{ height: '100%' }}>
      <Typography sx={{ py: 4 }} className='title_header'>
        HIỆN TRẠNG VẬN HÀNH HỒ ĐAKĐRINH
      </Typography>
      <TableContainer component={Paper}>
        <Table aria-label='simple table'>
          <TableHead className='tableHead'>
            <TableRow>
              <TableCell sx={{ py: '5px !important' }} rowSpan={3} align='center' className='red-text'>
                Thông số
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} colSpan={4} align='center' className='red-text'>
                Thực đo
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} colSpan={4} align='center' className='red-text'>
                Dự báo
              </TableCell>
            </TableRow>
            <TableRow>
              <TableCell sx={{ py: '5px !important' }} colSpan={2} align='center' className='red-text'>
                Ngày
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} colSpan={4} align='center' className='red-text'>
                Ngày
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} colSpan={2} align='center' className='red-text'>
                Ngày
              </TableCell>
            </TableRow>
            <TableRow>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                13h
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                19h
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                1h
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                7h
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                13h
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                19h
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                1h
              </TableCell>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                7h
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.map(row => (
              <TableRow key={row.label}>
                <TableCell component='th' scope='row' className='blue-text' sx={{ py: '5px !important' }}>
                  {row.label}
                </TableCell>
                {row.values.map((value, index) => (
                  <TableCell key={index}>{value}</TableCell>
                ))}
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Paper>
  )
}

export default HienTrangVanHanhHo
