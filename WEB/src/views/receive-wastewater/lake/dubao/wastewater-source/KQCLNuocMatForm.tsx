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
import { FormDuLieuThongSoDQTState } from './wasteWaterInterface'
import DialogsControlFullScreen from 'src/@core/components/dialog-control-full-screen'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])

  const [KQCLNuocMat, setKQCLNuocMat] = useState<FormDuLieuThongSoDQTState>({
    id: data?.id || 0,
    idDiemQT: data?.idDiemQT || 0,
    dot: data?.dot || '',
    ph: data?.ph || 0,
    do: data?.do || 0,
    tss: data?.tss || '',
    bod: data?.bod || '',
    cod: data?.cod || '',
    nO3: data?.nO3 || '',
    nO2: data?.nO2 || '',
    pO4: data?.pO4 || '',
    nH4: data?.nH4 || '',
    cl: data?.cl || '',
    fe: data?.fe || '',
    coliform: data?.coliform || 0,
    year: data?.year || 0
  })

  //dataselect
  useEffect(() => {
    setLoading(true)
    const getDataForSelect = async () => {
      try {
        const list = await getData('diem-quan-trac/danh-sach')
        setPhanDoanSong(list)
      } catch (error) {
        console.log(error)
      } finally {
        setLoading(false)
      }
    }
    getDataForSelect()
  }, [])
  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuThongSoDQTState) => (value: any) => {
    console.log(value);
    
    setKQCLNuocMat({ ...KQCLNuocMat, [prop]: value })
  }

  const handleSubmit = async (e: any) => {
    e.preventDefault()

    const handleApiCall = async () => {
      setSaving(true)
      try {
        const res = await saveData('ThongSoDiemQuanTrac/luu', KQCLNuocMat)
        if (res) {
          // Reset form fields
          setKQCLNuocMat({
            id: 0,
            idDiemQT: 0,
            dot: '',
            ph: 0,
            do: 0,
            tss: '',
            bod: '',
            cod: '',
            nO3: '',
            nO2: '',
            pO4: '',
            nH4: '',
            cl: '',
            fe: '',
            coliform: 0,
            year: 0
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
    setKQCLNuocMat({
      id: 0,
      idDiemQT: 0,
      dot: '',
      ph: 0,
      do: 0,
      tss: '',
      bod: '',
      cod: '',
      nO3: '',
      nO2: '',
      pO4: '',
      nH4: '',
      cl: '',
      fe: '',
      coliform: 0,
      year: 0
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
            getOptionLabel={(option: any) => `${option.tenDiemDo} `}
            value={phanDoanSong?.find((option: any) => option.id === KQCLNuocMat.idDiemQT) || null}
            onChange={(_, value) => {handleChange('idDiemQT')(value?.id || 0)}}
            renderInput={params => (
              <TextField
                {...params}
                fullWidth
                label='Chọn điểm quan trắc'
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
        <Grid item xs={12} md={3} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Năm quan trắc'
            fullWidth
            placeholder=''
            value={KQCLNuocMat.year || ''}
            onChange={event => handleChange('year')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={3} sm={12} sx={{ my: 2 }}>
          <TextField
            size='small'
            type='text'
            label='Đợt quan trắc'
            fullWidth
            placeholder=''
            value={KQCLNuocMat.dot || ''}
            onChange={event => handleChange('dot')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Thông số</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='PH'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.ph || ''}
                  onChange={event => handleChange('ph')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='DO(mg/l)'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.do || ''}
                  onChange={event => handleChange('do')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='TSS(mg/l)'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.tss || ''}
                  onChange={event => handleChange('tss')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5 (mg/l)'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.bod || ''}
                  onChange={event => handleChange('bod')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD (mg/l)'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.cod || ''}
                  onChange={event => handleChange('cod')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='NO3-N'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.nO3 || ''}
                  onChange={event => handleChange('nO3')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='NO2-N'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.nO2 || ''}
                  onChange={event => handleChange('nO2')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='PO4-'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.pO4 || ''}
                  onChange={event => handleChange('pO4')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='NH4+'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.nH4 || ''}
                  onChange={event => handleChange('nH4')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Cl- (mg/l)'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.cl || ''}
                  onChange={event => handleChange('cl')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Fe(mg/l)'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.fe || ''}
                  onChange={event => handleChange('fe')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Coliform (MPN/100ml)'
                  fullWidth
                  placeholder=''
                  value={KQCLNuocMat.coliform || ''}
                  onChange={event => handleChange('coliform')(event.target.value)}
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

const KQCLNuocMatForm = ({ data, setPostSuccess, isEdit }: any) => {
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

export default KQCLNuocMatForm
