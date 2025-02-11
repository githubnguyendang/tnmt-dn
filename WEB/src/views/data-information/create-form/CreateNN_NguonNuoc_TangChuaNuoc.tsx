import { useState } from 'react'
import { EditNote, Add, Save } from '@mui/icons-material'
import { Grid, Button, DialogActions, TextField, CircularProgress, Box } from '@mui/material'
import DialogsControl from 'src/@core/components/dialog-control'
import { saveData } from 'src/api/axios'

interface State {
  id: number
  tenTangChuaNuoc: string
  loaiChuaNuoc: string
  thuocLVS: string
  xaPhuongTT: string
  huyenTP: string
  dungTichPhanBo: number
  khoangChieuSauPhanBo: number
}

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [NN_NguonNuoc_TangChuaNuocData, setNN_NguonNuoc_TangChuaNuocData] = useState<State>({
    id: data?.id || 0,
    tenTangChuaNuoc: data?.tenTangChuaNuoc || '',
    loaiChuaNuoc: data?.loaiChuaNuoc || '',
    thuocLVS: data?.thuocLVS || '',
    xaPhuongTT: data?.xaPhuongTT || '',
    huyenTP: data?.huyenTP || '',
    dungTichPhanBo: data?.dungTichPhanBo || 0,
    khoangChieuSauPhanBo: data?.khoangChieuSauPhanBo || 0
  })

  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof State) => (value: any) => {
    setNN_NguonNuoc_TangChuaNuocData({ ...NN_NguonNuoc_TangChuaNuocData, [prop]: value })
  }

  const handleSubmit = async (e: any) => {
    e.preventDefault()

    const handleApiCall = async () => {
      setSaving(true)
      try {
        const res = await saveData('NN_NguonNuoc_TangChuaNuoc/luu', NN_NguonNuoc_TangChuaNuocData)
        if (res) {
          // Reset form fields
          setNN_NguonNuoc_TangChuaNuocData({
            id: 0,
            tenTangChuaNuoc: '',
            loaiChuaNuoc: '',
            thuocLVS: '',
            xaPhuongTT: '',
            huyenTP: '',
            dungTichPhanBo: 0,
            khoangChieuSauPhanBo: 0
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
    setNN_NguonNuoc_TangChuaNuocData({
      id: 0,
      tenTangChuaNuoc: '',
      loaiChuaNuoc: '',
      thuocLVS: '0',
      xaPhuongTT: '',
      huyenTP: '',
      dungTichPhanBo: 0,
      khoangChieuSauPhanBo: 0
    })

    closeDialogs()
  }

  return (
    <Box>
      <Grid container spacing={3}>
        <Grid item xs={12} md={6} sm={12}>
          <TextField
            size='small'
            type='text'
            label='Tên tầng chứa nước'
            fullWidth
            placeholder=''
            value={NN_NguonNuoc_TangChuaNuocData.tenTangChuaNuoc || ''}
            onChange={event => handleChange('tenTangChuaNuoc')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12}>
          <TextField
            size='small'
            type='text'
            label='Loại chứa nước'
            fullWidth
            placeholder=''
            value={NN_NguonNuoc_TangChuaNuocData.loaiChuaNuoc || ''}
            onChange={event => handleChange('loaiChuaNuoc')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12}>
          <TextField
            size='small'
            type='text'
            label='Thuộc lưu vực sông'
            fullWidth
            placeholder=''
            value={NN_NguonNuoc_TangChuaNuocData.thuocLVS || ''}
            onChange={event => handleChange('thuocLVS')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12}>
          <TextField
            size='small'
            type='text'
            label='Xã/Phường/Thị trấn'
            fullWidth
            placeholder=''
            value={NN_NguonNuoc_TangChuaNuocData.xaPhuongTT || ''}
            onChange={event => handleChange('xaPhuongTT')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12}>
          <TextField
            size='small'
            type='text'
            label='Huyện/Thành phố'
            fullWidth
            placeholder=''
            value={NN_NguonNuoc_TangChuaNuocData.huyenTP || ''}
            onChange={event => handleChange('huyenTP')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12}>
          <TextField
            size='small'
            type='text'
            label='Diện tích phân bổ (km2)'
            fullWidth
            placeholder=''
            value={NN_NguonNuoc_TangChuaNuocData.dungTichPhanBo || ''}
            onChange={event => handleChange('dungTichPhanBo')(event.target.value)}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12}>
          <TextField
            size='small'
            type='text'
            label='Khoảng chiều sâu phân bố (m)'
            fullWidth
            placeholder=''
            value={NN_NguonNuoc_TangChuaNuocData.khoangChieuSauPhanBo || ''}
            onChange={event => handleChange('khoangChieuSauPhanBo')(event.target.value)}
          />
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

const CreateNN_NguonNuoc_TangChuaNuoc = ({ data, setPostSuccess, isEdit }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin' : 'Thêm mới'

  return (
    <DialogsControl>
      {(openDialogs: (content: React.ReactNode, title: React.ReactNode) => void, closeDialogs: () => void) => (
        <Box>
          {isEdit ? (
            <Button>
              <EditNote
                className='tableActionBtn'
                onClick={() =>
                  openDialogs(
                    <Form data={data} setPostSuccess={setPostSuccess} closeDialogs={closeDialogs} />,
                    formTitle
                  )
                }
              />
            </Button>
          ) : (
            <Button
              variant='outlined'
              size='small'
              startIcon={<Add />}
              onClick={() =>
                openDialogs(<Form setPostSuccess={setPostSuccess} closeDialogs={closeDialogs} />, formTitle)
              }>
              Thêm mới
            </Button>
          )}
        </Box>
      )}
    </DialogsControl>
  )
}

export default CreateNN_NguonNuoc_TangChuaNuoc
