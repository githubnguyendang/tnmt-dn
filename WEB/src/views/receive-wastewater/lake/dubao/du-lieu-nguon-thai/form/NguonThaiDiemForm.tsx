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
import { FormDuLieuNguonThaiDiemDBState } from './DuLieuNguonThaiInterface'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])

  const [thaiDiem, setThaiDiem] = useState<FormDuLieuNguonThaiDiemDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || 0,
    luuLuongXaThaiDB: data?.luuLuongXaThaiDB || '',
    ctdiemBODDB: data?.ctdiemBODDB || 0,
    ctdiemCODDB: data?.ctdiemCODDB || 0,
    ctdiemAmoniDB: data?.ctdiemAmoniDB || 0,
    ctdiemTongNDB: data?.ctdiemTongNDB || 0,
    ctdiemTongPDB: data?.ctdiemTongPDB || 0,
    ctdiemTSSDB: data?.ctdiemTSSDB || 0,
    ctdiemColiformDB: data?.ctdiemColiformDB || 0,
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonThaiDiemDBState) => (value: any) => {
    setThaiDiem({ ...thaiDiem, [prop]: value })
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
        const res = await saveData('DuLieuNguonNuocThaiDiem/du-bao', thaiDiem)
        if (res) {
          // Reset form fields
          setThaiDiem({
            id: 0,
            idPhanDoanSong: 0,
            luuLuongXaThaiDB: 0,
            ctdiemBODDB: 0,
            ctdiemCODDB: 0,
            ctdiemAmoniDB: 0,
            ctdiemTongNDB: 0,
            ctdiemTongPDB: 0,
            ctdiemTSSDB: 0,
            ctdiemColiformDB: 0
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
    setThaiDiem({
      id: 0,
      idPhanDoanSong: 0,
      luuLuongXaThaiDB: 0,
      ctdiemBODDB: 0,
      ctdiemCODDB: 0,
      ctdiemAmoniDB: 0,
      ctdiemTongNDB: 0,
      ctdiemTongPDB: 0,
      ctdiemTSSDB: 0,
      ctdiemColiformDB: 0
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
            value={phanDoanSong?.find((option: any) => option.id === thaiDiem.idPhanDoanSong) || null}
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
       
        <Grid item xs={12} md={4} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Lưu lương xả thải max'
            fullWidth
            placeholder=''
            value={thaiDiem.luuLuongXaThaiDB || ''}
            onChange={event => handleChange('luuLuongXaThaiDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Kết quả phân tích thông số chất lượng nước nguồn thải điểm</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5'
                  fullWidth
                  placeholder=''
                  value={thaiDiem.ctdiemBODDB || ''}
                  onChange={event => handleChange('ctdiemBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={thaiDiem.ctdiemCODDB || ''}
                  onChange={event => handleChange('ctdiemCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={thaiDiem.ctdiemAmoniDB || ''}
                  onChange={event => handleChange('ctdiemAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={thaiDiem.ctdiemTongNDB || ''}
                  onChange={event => handleChange('ctdiemTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={thaiDiem.ctdiemTongPDB || ''}
                  onChange={event => handleChange('ctdiemTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={thaiDiem.ctdiemTSSDB || ''}
                  onChange={event => handleChange('ctdiemTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={thaiDiem.ctdiemColiformDB || ''}
                  onChange={event => handleChange('ctdiemColiformDB')(event.target.value)}
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

const ThaiDiemFormDB = ({ data, setPostSuccess, isEdit }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin ' : 'Dự báo nguồn thải điểm'

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

export default ThaiDiemFormDB
