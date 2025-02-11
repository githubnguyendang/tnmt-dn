//import { Replay, Search } from '@mui/icons-material'
import { Button, Grid, TextField, Toolbar } from '@mui/material'
import CreateSLDTKTSDN_NDD from '../../create-form/CreateSLDTKTSDN_NDD'
import { FC, useState } from 'react'
import { Replay, Search } from '@mui/icons-material'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'

interface LicenseToolBarProps {
  tableId: string
}
const ToolBar: FC<LicenseToolBarProps> = ({ tableId }) => {
  const [postSucceed, setPostSucceed] = useState(false)
  console.log(postSucceed)

  const handlePostSuccess = () => {
    setPostSucceed(prevState => !prevState)
  }

  return (
    <Toolbar variant='dense'>
      <Grid container spacing={2} sx={{ paddingY: 3 }} className='_flexEnd '>
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
          <ExportTableToExcel tableId={tableId} filename={tableId} />
        </Grid>
        <Grid item xs={6} md={1.5} py={0}>
          <CreateSLDTKTSDN_NDD isEdit={false} setPostSuccess={handlePostSuccess} />
        </Grid>
      </Grid>
    </Toolbar>
  )
}

export default ToolBar
