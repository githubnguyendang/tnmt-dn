import { Button, Grid, TextField, Typography } from '@mui/material'
import { TravelExplore } from '@mui/icons-material'

export interface ConstructionLocationState {
  tenHuyen: string
  tenXa: string
}
interface OrganizationInfo {
  tenTCCN: string
  diaChi: string
}

interface GiayPhep {
  tochuc_canhan: OrganizationInfo
}

export interface ConsState {
  tenCT: string
  maCT: string
  loaiCT: { tenLoaiCT: string }
  viTriCT: string
  vitri: ConstructionLocationState[]
  x: number
  y: number
  giayphep: GiayPhep[]
}

interface RequestDetailsProps {
  data: ConsState | null
  loading: boolean
}

const RequestDetails: React.FC<RequestDetailsProps> = ({ data, loading }) => {
  console.log(data)
  if (loading) {
    return (
      <Typography variant='h6' align='center'>
        Đang tải dữ liệu...
      </Typography>
    )
  }

  return (
    <fieldset className='field-request-info'>
      <legend>
        <Typography variant={'subtitle1'} className='legend__title'>
          Thông tin công trình
        </Typography>
      </legend>
      <Grid container spacing={4}>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Tên đơn vị XCP'
            value={data?.giayphep?.[0]?.tochuc_canhan?.tenTCCN|| ''}
            fullWidth
            placeholder=''
          />
        </Grid>
        <Grid item xs={12} md={8} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Địa chỉ đơn vị XCP'
            value={data?.giayphep?.[0]?.tochuc_canhan?.diaChi|| ''}
            fullWidth
            placeholder=''
          />
        </Grid>
      </Grid>
      <Grid container spacing={4}>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            value={data?.tenCT || ''}
            label='Tên công trình'
            fullWidth
            placeholder=''
          />
        </Grid>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField size='small' type='text' value={data?.maCT || ''} label='Ký hiệu CT' fullWidth placeholder='' />
        </Grid>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            value={data?.loaiCT?.tenLoaiCT || ''}
            label='Loại CT'
            fullWidth
            placeholder=''
          />
        </Grid>
      </Grid>
      <Grid container spacing={4}>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            value={data?.viTriCT || ''}
            label='Địa điểm CT'
            fullWidth
            placeholder=''
          />
        </Grid>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            value={data?.vitri?.[0]?.tenHuyen || ''}
            label='Huyện'
            fullWidth
            placeholder=''
          />
        </Grid>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            value={data?.vitri?.[0]?.tenXa || ''}
            label='Xã'
            fullWidth
            placeholder=''
          />
        </Grid>
      </Grid>
      <Grid container spacing={4}>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField size='small' type='text' value={data?.x || ''} label='Tọa độ X' fullWidth placeholder='' />
        </Grid>
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField size='small' type='text' value={data?.y || ''} label='Tọa độ Y' fullWidth placeholder='' />
        </Grid>
        <Grid item xs={12} md={2} sm={12} sx={{ my: 2 }}>
          <Button fullWidth variant='outlined'>
            <TravelExplore fontSize='small' /> &nbsp; Xem vị trí
          </Button>
        </Grid>
      </Grid>
      <Typography py={2} sx={{ fontSize: 12, fontStyle: 'italic' }}>
        Mỗi tài khoản ứng với 1 chủ công trình (1 chủ công trình có thể quản lý nhiều công trình)
      </Typography>
    </fieldset>
  )
}

export default RequestDetails
