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
import { FormDuLieuNguonThaiThuySanDBState } from './DuLieuNguonThaiInterface'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])
  console.log(data)

  const [ThuySan, setThuySan] = useState<FormDuLieuNguonThaiThuySanDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || '',
    dienTichThuySanDB: data?.dienTichThuySanDB || 0,
    heSoSuyGiamDB: data?.heSoSuyGiamDB || 0,
    ctThuySanBODDB: data?.ctThuySanBODDB || 0,
    ctThuySanCODDB: data?.ctThuySanCODDB || 0,
    ctThuySanAmoniDB: data?.ctThuySanAmoniDB || 0,
    ctThuySanTongNDB: data?.ctThuySanTongNDB || 0,
    ctThuySanTongPDB: data?.ctThuySanTongPDB || 0,
    ctThuySanTSSDB: data?.ctThuySanTSSDB || 0,
    ctThuySanColiformDB: data?.ctThuySanColiformDB || 0
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonThaiThuySanDBState) => (value: any) => {
    setThuySan({ ...ThuySan, [prop]: value })
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
        const res = await saveData('DuLieuNguonNuocThaiThuySanDB/du-bao', ThuySan)
        if (res) {
          // Reset form fields
          setThuySan({
            id: 0,
            idPhanDoanSong: 0,
            dienTichThuySanDB: 0,
            heSoSuyGiamDB: 0,
            ctThuySanBODDB: 0,
            ctThuySanCODDB: 0,
            ctThuySanAmoniDB: 0,
            ctThuySanTongNDB: 0,
            ctThuySanTongPDB: 0,
            ctThuySanTSSDB: 0,
            ctThuySanColiformDB: 0
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
    setThuySan({
      id: 0,
      idPhanDoanSong: 0,
      dienTichThuySanDB: 0,
      heSoSuyGiamDB: 0,
      ctThuySanBODDB: 0,
      ctThuySanCODDB: 0,
      ctThuySanAmoniDB: 0,
      ctThuySanTongNDB: 0,
      ctThuySanTongPDB: 0,
      ctThuySanTSSDB: 0,
      ctThuySanColiformDB: 0
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
            value={phanDoanSong?.find((option: any) => option.id === ThuySan.idPhanDoanSong) || null}
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
            label='Diện tích thủy sản'
            fullWidth
            placeholder=''
            value={ThuySan.dienTichThuySanDB || ''}
            onChange={event => handleChange('dienTichThuySanDB')(event.target.value)}
          />
        </Grid>

        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Hệ số suy giảm dọc đường'
            fullWidth
            placeholder=''
            value={ThuySan.heSoSuyGiamDB || ''}
            onChange={event => handleChange('heSoSuyGiamDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Kết quả phân tích thông số chất lượng nước nguồn thải thủy sản</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5'
                  fullWidth
                  placeholder=''
                  value={ThuySan.ctThuySanBODDB || ''}
                  onChange={event => handleChange('ctThuySanBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={ThuySan.ctThuySanCODDB || ''}
                  onChange={event => handleChange('ctThuySanCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={ThuySan.ctThuySanAmoniDB || ''}
                  onChange={event => handleChange('ctThuySanAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={ThuySan.ctThuySanTongNDB || ''}
                  onChange={event => handleChange('ctThuySanTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={ThuySan.ctThuySanTongPDB || ''}
                  onChange={event => handleChange('ctThuySanTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={ThuySan.ctThuySanTSSDB || ''}
                  onChange={event => handleChange('ctThuySanTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={ThuySan.ctThuySanColiformDB || ''}
                  onChange={event => handleChange('ctThuySanColiformDB')(event.target.value)}
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

const ThaiThuySanForm = ({ data, setPostSuccess, isEdit }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin ' : 'Dự báo thải thủy sản'

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

export default ThaiThuySanForm
