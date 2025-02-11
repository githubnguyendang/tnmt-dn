import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from '@mui/material'

const PhuongAnDieuHanhHo = () => {
  const data = [
    { label: 'BCH', values: Array(7).fill('') },
    { label: 'CT UB', values: Array(7).fill('') },
    { label: 'Q đến hồ (m3/s)', values: Array(7).fill('') },
    { label: 'Q xả mặt (m3/s)', values: Array(7).fill('') }
  ]

  return (
    <Paper sx={{ height: '100%' }}>
      <Typography sx={{ py: 4 }} className='title_header'>
        PHƯƠNG ÁN ĐIỀU HÀNH HỒ ĐĂKĐRINH
      </Typography>
      <TableContainer component={Paper}>
        <Table aria-label='simple table'>
          <TableHead className='tableHead'>
            <TableRow>
              <TableCell sx={{ py: '5px !important' }} align='center' className='red-text'>
                Điều hành{' '}
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

export default PhuongAnDieuHanhHo
