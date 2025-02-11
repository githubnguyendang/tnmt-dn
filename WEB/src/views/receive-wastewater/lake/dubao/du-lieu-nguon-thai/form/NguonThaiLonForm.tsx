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
import { FormDuLieuNguonThaiLonDBState } from './DuLieuNguonThaiInterface'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])
  console.log(data)

  const [Lon, setLon] = useState<FormDuLieuNguonThaiLonDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || '',
    soLonDB: data?.soLonDB || 0,
    soDeDB: data?.soDeDB || 0,
    soGiaSucKhacDB: data?.soGiaSucKhacDB || 0,
    heSoSuyGiamDB: data?.heSoSuyGiamDB || 0,
    ctLonBODDB: data?.ctLonBODDB || 0,
    ctLonCODDB: data?.ctLonCODDB || 0,
    ctLonAmoniDB: data?.ctLonAmoniDB || 0,
    ctLonTongNDB: data?.ctLonTongNDB || 0,
    ctLonTongPDB: data?.ctLonTongPDB || 0,
    ctLonTSSDB: data?.ctLonTSSDB || 0,
    ctLonColiformDB: data?.ctLonColiformDB || 0
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonThaiLonDBState) => (value: any) => {
    setLon({ ...Lon, [prop]: value })
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
        const res = await saveData('DuLieuNguonNuocThaiLonDB/du-bao', Lon)
        if (res) {
          // Reset form fields
          setLon({
            id: 0,
            idPhanDoanSong: 0,
            soLonDB: 0,
            soDeDB: 0,
            soGiaSucKhacDB: 0,
            heSoSuyGiamDB: 0,
            ctLonBODDB: 0,
            ctLonCODDB: 0,
            ctLonAmoniDB: 0,
            ctLonTongNDB: 0,
            ctLonTongPDB: 0,
            ctLonTSSDB: 0,
            ctLonColiformDB: 0
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
    setLon({
      id: 0,
      idPhanDoanSong: 0,
      soLonDB: 0,
      soDeDB: 0,
      soGiaSucKhacDB: 0,
      heSoSuyGiamDB: 0,
      ctLonBODDB: 0,
      ctLonCODDB: 0,
      ctLonAmoniDB: 0,
      ctLonTongNDB: 0,
      ctLonTongPDB: 0,
      ctLonTSSDB: 0,
      ctLonColiformDB: 0
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
            value={phanDoanSong?.find((option: any) => option.id === Lon.idPhanDoanSong) || null}
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
            label='Số lợn'
            fullWidth
            placeholder=''
            value={Lon.soLonDB || ''}
            onChange={event => handleChange('soLonDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Số dê'
            fullWidth
            placeholder=''
            value={Lon.soDeDB || ''}
            onChange={event => handleChange('soDeDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Số gia súc khác khác'
            fullWidth
            placeholder=''
            value={Lon.soGiaSucKhacDB || ''}
            onChange={event => handleChange('soGiaSucKhacDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Hệ số suy giảm dọc đường hay hệ số dòng chảy'
            fullWidth
            placeholder=''
            value={Lon.heSoSuyGiamDB || ''}
            onChange={event => handleChange('heSoSuyGiamDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Kết quả phân tích thông số chất lượng nước nguồn thải sinh hoạt</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5'
                  fullWidth
                  placeholder=''
                  value={Lon.ctLonBODDB || ''}
                  onChange={event => handleChange('ctLonBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={Lon.ctLonCODDB || ''}
                  onChange={event => handleChange('ctLonCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={Lon.ctLonAmoniDB || ''}
                  onChange={event => handleChange('ctLonAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={Lon.ctLonTongNDB || ''}
                  onChange={event => handleChange('ctLonTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={Lon.ctLonTongPDB || ''}
                  onChange={event => handleChange('ctLonTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={Lon.ctLonTSSDB || ''}
                  onChange={event => handleChange('ctLonTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={Lon.ctLonColiformDB || ''}
                  onChange={event => handleChange('ctLonColiformDB')(event.target.value)}
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

const ThaiLonForm = ({ data, setPostSuccess, isEdit }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin ' : 'Dự báo nguồn thải lợn'

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

export default ThaiLonForm
