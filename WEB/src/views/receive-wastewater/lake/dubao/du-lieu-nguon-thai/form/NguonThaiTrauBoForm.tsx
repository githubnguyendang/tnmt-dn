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
import { FormDuLieuNguonThaiTrauBoDBState } from './DuLieuNguonThaiInterface'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])
  console.log(data)

  const [trauBo, setTrauBo] = useState<FormDuLieuNguonThaiTrauBoDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || '',
    soTrauDB: data?.soTrauDB || 0,
    soBoDB: data?.soBoDB || 0,
    heSoSuyGiamDB: data?.heSoSuyGiamDB || 0,
    ctTrauBoBODDB: data?.ctTrauBoBODDB || 0,
    ctTrauBoCODDB: data?.ctTrauBoCODDB || 0,
    ctTrauBoAmoniDB: data?.ctTrauBoAmoniDB || 0,
    ctTrauBoTongNDB: data?.ctTrauBoTongNDB || 0,
    ctTrauBoTongPDB: data?.ctTrauBoTongPDB || 0,
    ctTrauBoTSSDB: data?.ctTrauBoTSSDB || 0,
    ctTrauBoColiformDB: data?.ctTrauBoColiformDB || 0
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonThaiTrauBoDBState) => (value: any) => {
    setTrauBo({ ...trauBo, [prop]: value })
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
        const res = await saveData('DuLieuNguonNuocThaiTrauBoDB/du-bao', trauBo)
        if (res) {
          // Reset form fields
          setTrauBo({
            id: 0,
            idPhanDoanSong: 0,
            soTrauDB: 0,
            soBoDB: 0,
            heSoSuyGiamDB: 0,
            ctTrauBoBODDB: 0,
            ctTrauBoCODDB: 0,
            ctTrauBoAmoniDB: 0,
            ctTrauBoTongNDB: 0,
            ctTrauBoTongPDB: 0,
            ctTrauBoTSSDB: 0,
            ctTrauBoColiformDB: 0
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
    setTrauBo({
      id: 0,
      idPhanDoanSong: 0,
      soTrauDB: 0,
      soBoDB: 0,
      heSoSuyGiamDB: 0,
      ctTrauBoBODDB: 0,
      ctTrauBoCODDB: 0,
      ctTrauBoAmoniDB: 0,
      ctTrauBoTongNDB: 0,
      ctTrauBoTongPDB: 0,
      ctTrauBoTSSDB: 0,
      ctTrauBoColiformDB: 0
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
            value={phanDoanSong?.find((option: any) => option.id === trauBo.idPhanDoanSong) || null}
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
            label='Số trâu'
            fullWidth
            placeholder=''
            value={trauBo.soTrauDB || ''}
            onChange={event => handleChange('soTrauDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Số bò'
            fullWidth
            placeholder=''
            value={trauBo.soBoDB || ''}
            onChange={event => handleChange('soBoDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Hệ số suy giảm dọc đường hay hệ số dòng chảy'
            fullWidth
            placeholder=''
            value={trauBo.heSoSuyGiamDB || ''}
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
                  value={trauBo.ctTrauBoBODDB || ''}
                  onChange={event => handleChange('ctTrauBoBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={trauBo.ctTrauBoCODDB || ''}
                  onChange={event => handleChange('ctTrauBoCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={trauBo.ctTrauBoAmoniDB || ''}
                  onChange={event => handleChange('ctTrauBoAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={trauBo.ctTrauBoTongNDB || ''}
                  onChange={event => handleChange('ctTrauBoTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={trauBo.ctTrauBoTongPDB || ''}
                  onChange={event => handleChange('ctTrauBoTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={trauBo.ctTrauBoTSSDB || ''}
                  onChange={event => handleChange('ctTrauBoTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={trauBo.ctTrauBoColiformDB || ''}
                  onChange={event => handleChange('ctTrauBoColiformDB')(event.target.value)}
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

const ThaiTrauBoForm = ({ data, setPostSuccess, isEdit }: any) => {
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

export default ThaiTrauBoForm
