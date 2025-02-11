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
import { FormDuLieuNguonThaiGiaCamDBState } from './DuLieuNguonThaiInterface'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])
  console.log(data)

  const [GiaCam, setGiaCam] = useState<FormDuLieuNguonThaiGiaCamDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || '',
    soGiaCamDB: data?.soGiaCamDB || 0,
    heSoSuyGiamDB: data?.heSoSuyGiamDB || 0,
    ctGiaCamBODDB: data?.ctGiaCamBODDB || 0,
    ctGiaCamCODDB: data?.ctGiaCamCODDB || 0,
    ctGiaCamAmoniDB: data?.ctGiaCamAmoniDB || 0,
    ctGiaCamTongNDB: data?.ctGiaCamTongNDB || 0,
    ctGiaCamTongPDB: data?.ctGiaCamTongPDB || 0,
    ctGiaCamTSSDB: data?.ctGiaCamTSSDB || 0,
    ctGiaCamColiformDB: data?.ctGiaCamColiformDB || 0
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonThaiGiaCamDBState) => (value: any) => {
    setGiaCam({ ...GiaCam, [prop]: value })
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
        const res = await saveData('DuLieuNguonNuocThaiGiaCamDB/du-bao', GiaCam)
        if (res) {
          // Reset form fields
          setGiaCam({
            id: 0,
            idPhanDoanSong: 0,
            soGiaCamDB: 0,
            heSoSuyGiamDB: 0,
            ctGiaCamBODDB: 0,
            ctGiaCamCODDB: 0,
            ctGiaCamAmoniDB: 0,
            ctGiaCamTongNDB: 0,
            ctGiaCamTongPDB: 0,
            ctGiaCamTSSDB: 0,
            ctGiaCamColiformDB: 0
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
    setGiaCam({
      id: 0,
      idPhanDoanSong: 0,
      soGiaCamDB: 0,
      heSoSuyGiamDB: 0,
      ctGiaCamBODDB: 0,
      ctGiaCamCODDB: 0,
      ctGiaCamAmoniDB: 0,
      ctGiaCamTongNDB: 0,
      ctGiaCamTongPDB: 0,
      ctGiaCamTSSDB: 0,
      ctGiaCamColiformDB: 0
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
            value={phanDoanSong?.find((option: any) => option.id === GiaCam.idPhanDoanSong) || null}
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
            label='Số con gia cầm'
            fullWidth
            placeholder=''
            value={GiaCam.soGiaCamDB || ''}
            onChange={event => handleChange('soGiaCamDB')(event.target.value)}
          />
        </Grid>

        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Hệ số suy giảm dọc đường hay hệ số dòng chảy'
            fullWidth
            placeholder=''
            value={GiaCam.heSoSuyGiamDB || ''}
            onChange={event => handleChange('heSoSuyGiamDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Kết quả phân tích thông số chất lượng nước nguồn thải gia cầm</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5'
                  fullWidth
                  placeholder=''
                  value={GiaCam.ctGiaCamBODDB || ''}
                  onChange={event => handleChange('ctGiaCamBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={GiaCam.ctGiaCamCODDB || ''}
                  onChange={event => handleChange('ctGiaCamCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={GiaCam.ctGiaCamAmoniDB || ''}
                  onChange={event => handleChange('ctGiaCamAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={GiaCam.ctGiaCamTongNDB || ''}
                  onChange={event => handleChange('ctGiaCamTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={GiaCam.ctGiaCamTongPDB || ''}
                  onChange={event => handleChange('ctGiaCamTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={GiaCam.ctGiaCamTSSDB || ''}
                  onChange={event => handleChange('ctGiaCamTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={GiaCam.ctGiaCamColiformDB || ''}
                  onChange={event => handleChange('ctGiaCamColiformDB')(event.target.value)}
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

const ThaiGiaCamForm = ({ data, setPostSuccess, isEdit }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin ' : 'Thêm mới'

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

export default ThaiGiaCamForm
