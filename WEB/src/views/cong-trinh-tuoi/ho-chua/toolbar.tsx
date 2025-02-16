//import { Replay, Search } from '@mui/icons-material'
import { Button, FormControl, Grid, MenuItem, Select, TextField, Toolbar } from '@mui/material'

import { FC } from 'react'
import ExportToExcel from 'src/@core/components/export-excel'
import { TableColumn } from 'src/@core/components/table'
import { Replay, Search } from '@mui/icons-material'

interface LicenseToolBarProps {
  onExport: { data: any; column: TableColumn[] }
}
const ToolBar: FC<LicenseToolBarProps> = ({ onExport }) => {
  return (
    <Toolbar variant='dense'>
      <Grid container spacing={2} sx={{ paddingY: 3 }} className='_flexEnd '>
        <Grid item xs={12} md={2} py={0}>
          <FormControl fullWidth>
            <Select size='small' defaultValue='0'>
              <MenuItem value='0'>Chọn hình thế thời tiết</MenuItem>
              <MenuItem value='A'>(A) Bão hoặc ATNĐ hoặc áp thấp</MenuItem>
              <MenuItem value='B'>(B) Bão hoặc ATNĐ + KKL</MenuItem>
              <MenuItem value='C'>(C) Giải HTNĐ + KKL</MenuItem>
              <MenuItem value='D'>(D) KKL + đới gió đông</MenuItem>
              <MenuItem value='E'>(E) Tổ hợp hình thế thời tiết khác</MenuItem>
              <MenuItem value='F'>(F) Tổ hợp các hình thế trên</MenuItem>
            </Select>
          </FormControl>
        </Grid>
        <Grid item xs={12} md={2} py={0}>
          <FormControl fullWidth>
            <TextField sx={{ p: 0 }} size='small' fullWidth variant='outlined' placeholder='Lượng mưa dự báo...' />
          </FormControl>
        </Grid>
        <Grid item xs={12} md={3} py={0}>
          <TextField sx={{ p: 0 }} size='small' fullWidth variant='outlined' placeholder='Tên trạm...' />
        </Grid>
        <Grid item xs={6} md={1.5} py={0}>
          <Button variant='outlined' size='small' fullWidth startIcon={<Search />}>
            Tìm kiếm
          </Button>
        </Grid>
        <Grid item xs={6} md={1.5} py={0}>
          <Button variant='outlined' size='small' fullWidth startIcon={<Replay />}>
            Tải lại
          </Button>
        </Grid>
        <Grid item xs={6} md={1.5} py={0}>
          <ExportToExcel resData={onExport?.data} columnsTable={onExport?.column} />
        </Grid>
        <Grid item xs={6} md={1.5} py={0}></Grid>
      </Grid>
    </Toolbar>
  )
}

export default ToolBar
