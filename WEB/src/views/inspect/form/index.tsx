import DialogsControl from 'src/@core/components/dialog-control'
import { Add, Cancel, CloudUpload, EditNote, Save } from '@mui/icons-material'
import { Grid, Button, TextField, IconButton, Box, Typography } from '@mui/material'
import { ChangeEvent, useState } from 'react'

import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import dayjs from 'dayjs'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { InspectState, emptyInspectData } from './inspect-interface'
import { VisuallyHiddenInput } from 'src/@core/theme/VisuallyHiddenInput'
import { saveData, uploadFile } from 'src/api/axios'

const Form = ({ data, setPostSuccess, closeDialogs }: any) => {
  const [values, setValues] = useState<InspectState>({
    id: data?.id || 0,
    soVanBan: data?.soVanBan || '',
    thoiGian: dayjs(data?.thoiGian) || null,
    tienPhat: data?.tienPhat || 0,
    dot: data?.dot || '',
    donVi: data?.donVi || '',
    ghiChu: data?.ghiChu || '',
    taiLieu: data?.taiLieu || null,
    daXoa: false
  })
  // const [listLicense, setListLicense] = useState([])
  // const [licenseId, setLicenseId] = useState<any>([])
  const [fileUpload, setFileUpload] = useState<any>()
  // const [fetching, setFetching] = useState(false)
  // const [saving, setSaving] = useState(false)

  // Hooks
  // const router = useRouter()

  const handleChange = (prop: keyof InspectState) => (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.type === 'checkbox' ? event.target.checked : event.target.value
    setValues({ ...values, [prop]: value })
  }

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0] || null
    setFileUpload(file)
  }

  // const [filterLicense] = useState({
  //   so_gp: null,
  //   cong_trinh: null,
  //   coquan_cp: null,
  //   loaihinh_cp: 0,
  //   hieuluc_gp: null,
  //   loai_ct: 0,
  //   tang_chuanuoc: 0,
  //   huyen: 0,
  //   xa: 0,
  //   tieuvung_qh: 0,
  //   tochuc_canhan: 0,
  //   tu_nam: 0,
  //   den_nam: 0
  // })

  // useEffect(() => {
  //   const getDataInspects = async () => {
  //     // setFetching(true)
  //     try {
  //       // const listLic = await getData('giay-phep/danh-sach/', { ...filterLicense, coquan_cp: 'ubndt' })
  //       // setListLicense(listLic)
  //     } catch (error) {
  //     } finally {
  //       // setFetching(false)
  //     }
  //   }
  //   getDataInspects()
  // }, [filterLicense, router.pathname])

  const handleSubmit = async (e: any) => {
    e.preventDefault()

    const handleApiCall = async () => {
      const newVal = {
        ...values,
        thoiGian: values.thoiGian?.toDate(),
        taiLieu: `pdf/thanh-tra-kiem-tra/${values.thoiGian?.year()}/${values.soVanBan
          ?.replace(/\//g, '_')
          .toLowerCase()}.pdf`
      }

      const newFile = {
        filePath: `pdf/thanh-tra-kiem-tra/${newVal.thoiGian?.getFullYear()}`,
        fileName: `${values.soVanBan?.replace(/\//g, '_').toLowerCase()}.pdf`,
        file: fileUpload
      }

      // setSaving(true)
      try {
        const res = await saveData('thanh-tra-kiem-tra/luu', newVal)
        if (res) {
          await uploadFile(newFile)

          // Reset form fields
          setValues(emptyInspectData)

          typeof setPostSuccess === 'function' ? setPostSuccess(true) : ''
          closeDialogs()
        }
      } catch (error) {
        console.log(error)
      } finally {
        // setSaving(false)
      }
    }

    // Call the function
    handleApiCall()
  }
  const handleClose = () => {
    setValues(emptyInspectData)
    closeDialogs()
  }

  return (
    <form onSubmit={handleSubmit}>
      <Box>
        <Grid container spacing={4} py={2}>
          <Grid item md={12}>
            <TextField
              name='soVanBan'
              fullWidth
              label='Số băn bản'
              placeholder='Số băn bản'
              size='small'
              value={values.soVanBan}
              onChange={handleChange('soVanBan')}
            />
          </Grid>
          <Grid item md={12}>
            <TextField
              name='dot'
              fullWidth
              label='Đợt thanh tra'
              placeholder='Đợt thanh tra'
              size='small'
              value={values.dot}
              onChange={handleChange('dot')}
            />
          </Grid>
          <Grid item md={12}>
            <TextField
              name='donVi'
              fullWidth
              label='Đơn vị thanh tra'
              placeholder='Đơn vị thanh tra'
              size='small'
              value={values.donVi}
              onChange={handleChange('donVi')}
            />
          </Grid>
          <Grid item md={6}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DatePicker
                value={dayjs(values.thoiGian)}
                onChange={(newthoiGian: any) => handleChange('thoiGian')(newthoiGian.toDate())}
                slotProps={{ textField: { size: 'small', fullWidth: true } }}
                label='Ngày thanh tra'
                format='DD/MM/YYYY'
              />
            </LocalizationProvider>
          </Grid>
          <Grid item md={6}>
            <TextField
              name='tienPhat'
              fullWidth
              label='Tổng tiền phạt'
              placeholder='Tổng tiền phạt'
              size='small'
              value={values.tienPhat}
              onChange={handleChange('tienPhat')}
            />
          </Grid>
          <Grid item md={12}>
            <TextField
              name='ghiChu'
              fullWidth
              multiline
              label='Ghi chú'
              placeholder='Ghi chú'
              size='small'
              value={values.ghiChu}
              onChange={handleChange('ghiChu')}
            />
          </Grid>
          <Grid item md={12}>
            {values.fileUpload && <Typography mb={3}>{values.fileUpload?.name}</Typography>}
            <Button
              fullWidth
              className='uploadBtn'
              component='label'
              variant='contained'
              startIcon={<CloudUpload />}
              href={`#file-upload-licFee`}>
              Văn bản kết luận thanh tra
              <VisuallyHiddenInput type='file' onChange={e => handleFileChange(e)} accept='.pdf' />
            </Button>
          </Grid>
        </Grid>
        <Grid item sx={{ display: 'flex', justifyContent: 'end', py: 2 }}>
          <Button startIcon={<Save />} sx={{ ml: 1 }} variant='outlined' color='primary' type='submit'>
            Lưu
          </Button>
          <Button startIcon={<Cancel />} sx={{ ml: 1 }} variant='outlined' color='error' onClick={handleClose}>
            Huỷ
          </Button>
        </Grid>
      </Box>
    </form>
  )
}

const FormInspect = ({ data, isEdit, setPostSuccess }: any) => {
  const formTitle = isEdit ? 'Thay đổi thông tin thanh tra - kiểm tra' : 'Thêm thanh tra - kiểm tra'

  return (
    <DialogsControl>
      {(openDialogs: (content: React.ReactNode, title: React.ReactNode) => void, closeDialogs: () => void) => (
        <Box>
          {isEdit ? (
            <IconButton
              onClick={() =>
                openDialogs(
                  <Form data={data} setPostSuccess={setPostSuccess} isEdit={isEdit} closeDialogs={closeDialogs} />,
                  formTitle
                )
              }>
              <EditNote className='tableActionBtn' />
            </IconButton>
          ) : (
            <Button
              size='small'
              startIcon={<Add />}
              onClick={() =>
                openDialogs(
                  <Form data={data} setPostSuccess={setPostSuccess} isEdit={isEdit} closeDialogs={closeDialogs} />,
                  formTitle
                )
              }>
              Thêm mới
            </Button>
          )}
        </Box>
      )}
    </DialogsControl>
  )
}

export default FormInspect
