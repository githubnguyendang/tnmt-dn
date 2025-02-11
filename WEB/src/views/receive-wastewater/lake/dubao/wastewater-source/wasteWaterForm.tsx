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
import { FormDuLieuNguonNhanDBState } from './wasteWaterInterface'
import DialogsControlFullScreen from 'src/@core/components/dialog-control-full-screen'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [phanDoanSong, setPhanDoanSong] = useState([])
  const [thongSoQC, setThongSoQC] = useState([])
  const [report1Data, setreport1Data] = useState<FormDuLieuNguonNhanDBState>({
    id: data?.id || 0,
    idPhanDoanSong: data?.idPhanDoanSong || 0,
    idMucPL: data?.idMucPL || 0,
    luuLuongDongChayDB: data?.luuLuongDongChayDB || 0,
    cnnBODDB: data?.cnnBODDB || 0,
    cnnCODDB: data?.cnnCODDB || 0,
    cnnAmoniDB: data?.cnnAmoniDB || 0,
    cnnTongNDB: data?.cnnTongNDB || 0,
    cnnTongPDB: data?.cnnTongPDB || 0,
    cnnTSSDB: data?.cnnTSSDB || 0,
    cnnColiformDB: data?.cnnColiformDB || 0,
  })

  //dataselect
  useEffect(() => {
    setLoading(true)
    const getDataForSelect = async () => {
      try {
        const list = await getData('PhanDoanSong/danh-sach')
        setPhanDoanSong(list)
        const quychuan = await getData('ThongSoCLNDuBao/danhsach')
        setThongSoQC(quychuan)
      } catch (error) {
        console.log(error)
      } finally {
        setLoading(false)
      }
    }
    getDataForSelect()
  }, [])
  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuLieuNguonNhanDBState) => (value: any) => {
    setreport1Data({ ...report1Data, [prop]: value })
  }

  const handleSubmit = async (e: any) => {
    e.preventDefault()

    const handleApiCall = async () => {
      setSaving(true)
      try {
        const res = await saveData('DuLieuNguonNuocNhanDB/du-bao', report1Data)
        if (res) {
          // Reset form fields
          setreport1Data({
            id: 0,
            idPhanDoanSong: 0,
            idMucPL: 0,
            luuLuongDongChayDB: 0,
            cnnBODDB: 0,
            cnnCODDB: 0,
            cnnAmoniDB: 0,
            cnnTongNDB: 0,
            cnnTongPDB: 0,
            cnnTSSDB: 0,
            cnnColiformDB: 0
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
    setreport1Data({
      id: 0,
      idPhanDoanSong: 0,
      idMucPL: 0,
      luuLuongDongChayDB: 0,
      cnnBODDB: 0,
      cnnCODDB: 0,
      cnnAmoniDB: 0,
      cnnTongNDB: 0,
      cnnTongPDB: 0,
      cnnTSSDB: 0,
      cnnColiformDB: 0
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
            value={phanDoanSong?.find((option: any) => option.id === report1Data.idPhanDoanSong) || null}
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
        <Grid item xs={12} md={3} sm={12} sx={{ my: 2 }}>
          <Autocomplete
            size='small'
            options={thongSoQC}
            getOptionLabel={(option: any) => `${option.mucPLCLNuoc} `}
            value={thongSoQC?.find((option: any) => option.id === report1Data.idMucPL) || null}
            onChange={(_, value) => handleChange('idMucPL')(value?.id || 0)}
            renderInput={params => (
              <TextField
                {...params}
                fullWidth
                label='Chọn mức phân loại chất lượng nước theo QCVN08/2023'
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
            label='Lưu lượng dòng chảy'
            fullWidth
            placeholder=''
            value={report1Data.luuLuongDongChayDB || ''}
            onChange={event => handleChange('luuLuongDongChayDB')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <fieldset>
            <legend>Kết quả phân tích thông số chất lượng nước mặt</legend>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='BOD5'
                  fullWidth
                  placeholder=''
                  value={report1Data.cnnBODDB || ''}
                  onChange={event => handleChange('cnnBODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='COD'
                  fullWidth
                  placeholder=''
                  value={report1Data.cnnCODDB || ''}
                  onChange={event => handleChange('cnnCODDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Amoni'
                  fullWidth
                  placeholder=''
                  value={report1Data.cnnAmoniDB || ''}
                  onChange={event => handleChange('cnnAmoniDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng N'
                  fullWidth
                  placeholder=''
                  value={report1Data.cnnTongNDB || ''}
                  onChange={event => handleChange('cnnTongNDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng P'
                  fullWidth
                  placeholder=''
                  value={report1Data.cnnTongPDB || ''}
                  onChange={event => handleChange('cnnTongPDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng chất rắn lơ lửng TSS'
                  fullWidth
                  placeholder=''
                  value={report1Data.cnnTSSDB || ''}
                  onChange={event => handleChange('cnnTSSDB')(event.target.value)}
                />
              </Grid>
              <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
                <TextField
                  size='small'
                  type='text'
                  label='Tổng coliform'
                  fullWidth
                  placeholder=''
                  value={report1Data.cnnColiformDB || ''}
                  onChange={event => handleChange('cnnColiformDB')(event.target.value)}
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

const CreateWasteFormDB = ({ data, setPostSuccess, isEdit }: any) => {
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

export default CreateWasteFormDB
