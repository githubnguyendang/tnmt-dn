import { Fragment, useEffect, useState } from 'react'
import { Add, Edit, Save } from '@mui/icons-material'
import {
  Grid,
  Button,
  DialogActions,
  IconButton,
  TextField,
  CircularProgress,
  Tooltip,
  Autocomplete,
  Box
} from '@mui/material'
import { getData, saveData } from 'src/api/axios'
import DialogsControlFullScreen from 'src/@core/components/dialog-control-full-screen'
import { FormDuLieuNguonThaiSinhHoatDBState } from './DuLieuNguonThaiInterface'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])

  const [sinhHoat, setSinhHoat] = useState<FormDuLieuNguonThaiSinhHoatDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || '',
    soDanDB: data?.soDanDB || 0,
    heSoSuyGiamDB: data?.heSoSuyGiamDB || 0,
    ctSinhHoatBODDB: data?.ctSinhHoatBODDB || 0,
    ctSinhHoatCODDB: data?.ctSinhHoatCODDB || 0,
    ctSinhHoatAmoniDB: data?.ctSinhHoatAmoniDB || 0,
    ctSinhHoatTongNDB: data?.ctSinhHoatTongNDB || 0,
    ctSinhHoatTongPDB: data?.ctSinhHoatTongPDB || 0,
    ctSinhHoatTSSDB: data?.ctSinhHoatTSSDB || 0,
    ctSinhHoatColiformDB: data?.ctSinhHoatColiformDB || 0
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonThaiSinhHoatDBState) => (value: any) => {
    setSinhHoat({ ...sinhHoat, [prop]: value })
  }

  //dataselect
  useEffect(() => {
    setLoading(true)
    const getDataForSelect = async () => {
      try {
        const list = await getData('PhanDoanSong/danh-sach')
        setPhanDoanSong(list)
      } catch (error) {
        console.log(error)
      } finally {
        setLoading(false)
      }
    }
    getDataForSelect()
  }, [])

  const handleSubmit = async (e: any) => {
    e.preventDefault()

    const handleApiCall = async () => {
      setSaving(true)
      try {
        const res = await saveData('DuLieuNguonNuocThaiSinhHoatDB/du-bao', sinhHoat)
        if (res) {
          // Reset form fields
          setSinhHoat({
            id: 0,
            idPhanDoanSong: 0,
            soDanDB: 0,
            heSoSuyGiamDB: 0,
            ctSinhHoatBODDB: 0,
            ctSinhHoatCODDB: 0,
            ctSinhHoatAmoniDB: 0,
            ctSinhHoatTongNDB: 0,
            ctSinhHoatTongPDB: 0,
            ctSinhHoatTSSDB: 0,
            ctSinhHoatColiformDB: 0
          })

          typeof setPostSuccess === 'function' ? setPostSuccess(true) : ''
          closeDialogs()
        }
      } catch (error) {
        console.log(error)
      } finally {
        6
        setSaving(false)
      }
    }

    // Call the function
    handleApiCall()
  }

  const handleClose = () => {
    setSinhHoat({
      id: 0,
      idPhanDoanSong: 0,
      soDanDB: 0,
      heSoSuyGiamDB: 0,
      ctSinhHoatBODDB: 0,
      ctSinhHoatCODDB: 0,
      ctSinhHoatAmoniDB: 0,
      ctSinhHoatTongNDB: 0,
      ctSinhHoatTongPDB: 0,
      ctSinhHoatTSSDB: 0,
      ctSinhHoatColiformDB: 0
    })

    closeDialogs()
  }

  return (
    <Box>
      <Grid container spacing={3}>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <Autocomplete
            size='small'
            options={phanDoanSong}
            getOptionLabel={(option: any) => `${option.phanDoan} `}
            value={phanDoanSong?.find((option: any) => option.id === sinhHoat.idPhanDoanSong) || null}
            onChange={(_, value) => handleChange('idPhanDoanSong')(value?.id || 0)}
            renderInput={params => (
              <TextField
                {...params}
                fullWidth
                label='Chọn phân đoạn sông'
                InputProps={{
                  ...params.InputProps,
                  endAdornment: (
                    <Fragment>
                      {loading && <CircularProgress color='primary' size={20} />}
                      {params.InputProps.endAdornment}
                    </Fragment>
                  )
                }}
              />
            )}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Số dân'
            fullWidth
            placeholder=''
            value={sinhHoat.soDanDB || ''}
            onChange={event => handleChange('soDanDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Hệ số suy giảm dọc đường hay hệ số dòng chảy'
            fullWidth
            placeholder=''
            value={sinhHoat.heSoSuyGiamDB || ''}
            onChange={event => handleChange('heSoSuyGiamDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Kết quả dự báo thông số chất lượng nước nguồn thải sinh hoạt</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5'
                  fullWidth
                  placeholder=''
                  value={sinhHoat.ctSinhHoatBODDB || ''}
                  onChange={event => handleChange('ctSinhHoatBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={sinhHoat.ctSinhHoatCODDB || ''}
                  onChange={event => handleChange('ctSinhHoatCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={sinhHoat.ctSinhHoatAmoniDB || ''}
                  onChange={event => handleChange('ctSinhHoatAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={sinhHoat.ctSinhHoatTongNDB || ''}
                  onChange={event => handleChange('ctSinhHoatTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={sinhHoat.ctSinhHoatTongPDB || ''}
                  onChange={event => handleChange('ctSinhHoatTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={sinhHoat.ctSinhHoatTSSDB || ''}
                  onChange={event => handleChange('ctSinhHoatTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={sinhHoat.ctSinhHoatColiformDB || ''}
                  onChange={event => handleChange('ctSinhHoatColiformDB')(event.target.value)}
                />
              </Grid>
            </Grid>
          </fieldset>
        </Grid>

      </Grid>

      <DialogActions sx={{ p: 0, mt: 5 }}>
        <Button size='small' onClick={handleClose} className='btn cancleBtn'>
          Hủy
        </Button>
        <Button disabled={saving} className='btn saveBtn' onClick={handleSubmit}>
          {' '}
          {saving ? <CircularProgress color='inherit' size={20} /> : <Save />} &nbsp; Lưu{' '}
        </Button>
      </DialogActions>
    </Box>
  )
}

const ThaiSinhHoatDBForm = ({ data, setPostSuccess, isEdit }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin ' : 'Dự báo thải sinh hoạt'

  return (
    <DialogsControlFullScreen>
      {(openDialogs: (content: React.ReactNode, title: React.ReactNode) => void, closeDialogs: () => void) => (
        <Box>
          {isEdit ? (
            <Tooltip title='Chỉnh sửa thông tin công trình'>
              <IconButton
                onClick={() =>
                  openDialogs(
                    <Form data={data} closeDialogs={closeDialogs} setPostSuccess={setPostSuccess} />,
                    formTitle
                  )
                }>
                <Edit className='tableActionBtn' />
              </IconButton>
            </Tooltip>
          ) : (
            <Button
              variant='outlined'
              size='small'
              startIcon={<Add />}
              onClick={() =>
                openDialogs(<Form data={data} closeDialogs={closeDialogs} setPostSuccess={setPostSuccess} />, formTitle)
              }>
              Thêm mới
            </Button>
          )}
        </Box>
      )}
    </DialogsControlFullScreen>
  )
}

export default ThaiSinhHoatDBForm
