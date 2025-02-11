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
import { FormDuLieuNguonThaiTrongLuaDBState } from './DuLieuNguonThaiInterface'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])
  console.log(data)

  const [TrongLua, setTrongLua] = useState<FormDuLieuNguonThaiTrongLuaDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || '',
    dienTichTrongLuaDB: data?.dienTichTrongLuaDB || 0,
    heSoSuyGiamDB: data?.heSoSuyGiamDB || 0,
    ctTrongLuaBODDB: data?.ctTrongLuaBODDB || 0,
    ctTrongLuaCODDB: data?.ctTrongLuaCODDB || 0,
    ctTrongLuaAmoniDB: data?.ctTrongLuaAmoniDB || 0,
    ctTrongLuaTongNDB: data?.ctTrongLuaTongNDB || 0,
    ctTrongLuaTongPDB: data?.ctTrongLuaTongPDB || 0,
    ctTrongLuaTSSDB: data?.ctTrongLuaTSSDB || 0,
    ctTrongLuaColiformDB: data?.ctTrongLuaColiformDB || 0
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonThaiTrongLuaDBState) => (value: any) => {
    setTrongLua({ ...TrongLua, [prop]: value })
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
        const res = await saveData('DuLieuNguonNuocThaiTrongLuaDB/du-bao', TrongLua)
        if (res) {
          // Reset form fields
          setTrongLua({
            id: 0,
            idPhanDoanSong: 0,
            dienTichTrongLuaDB: 0,
            heSoSuyGiamDB: 0,
            ctTrongLuaBODDB: 0,
            ctTrongLuaCODDB: 0,
            ctTrongLuaAmoniDB: 0,
            ctTrongLuaTongNDB: 0,
            ctTrongLuaTongPDB: 0,
            ctTrongLuaTSSDB: 0,
            ctTrongLuaColiformDB: 0
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
    setTrongLua({
      id: 0,
      idPhanDoanSong: 0,
      dienTichTrongLuaDB: 0,
      heSoSuyGiamDB: 0,
      ctTrongLuaBODDB: 0,
      ctTrongLuaCODDB: 0,
      ctTrongLuaAmoniDB: 0,
      ctTrongLuaTongNDB: 0,
      ctTrongLuaTongPDB: 0,
      ctTrongLuaTSSDB: 0,
      ctTrongLuaColiformDB: 0
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
            value={phanDoanSong?.find((option: any) => option.id === TrongLua.idPhanDoanSong) || null}
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
            label='Diện tích trồng lúa'
            fullWidth
            placeholder=''
            value={TrongLua.dienTichTrongLuaDB || ''}
            onChange={event => handleChange('dienTichTrongLuaDB')(event.target.value)}
          />
        </Grid>

        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Hệ số suy giảm dọc đường'
            fullWidth
            placeholder=''
            value={TrongLua.heSoSuyGiamDB || ''}
            onChange={event => handleChange('heSoSuyGiamDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Kết quả phân tích thông số chất lượng nước nguồn thải trồng lúa</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5'
                  fullWidth
                  placeholder=''
                  value={TrongLua.ctTrongLuaBODDB || ''}
                  onChange={event => handleChange('ctTrongLuaBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={TrongLua.ctTrongLuaCODDB || ''}
                  onChange={event => handleChange('ctTrongLuaCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={TrongLua.ctTrongLuaAmoniDB || ''}
                  onChange={event => handleChange('ctTrongLuaAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={TrongLua.ctTrongLuaTongNDB || ''}
                  onChange={event => handleChange('ctTrongLuaTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={TrongLua.ctTrongLuaTongPDB || ''}
                  onChange={event => handleChange('ctTrongLuaTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={TrongLua.ctTrongLuaTSSDB || ''}
                  onChange={event => handleChange('ctTrongLuaTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={TrongLua.ctTrongLuaColiformDB || ''}
                  onChange={event => handleChange('ctTrongLuaColiformDB')(event.target.value)}
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

const ThaiTrongLuaForm = ({ data, setPostSuccess, isEdit }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin ' : 'Dự báo thải trồng lúa'

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

export default ThaiTrongLuaForm
