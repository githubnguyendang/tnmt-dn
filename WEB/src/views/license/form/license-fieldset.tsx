import { useState, FC, useEffect } from 'react'

//MUI Imports
import {
  Typography,
  Grid,
  TextField,
  Autocomplete,
  CircularProgress,
  Button,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Box,
  Modal
} from '@mui/material'

//DatePicker Imports
import dayjs from 'dayjs'
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { DatePicker } from '@mui/x-date-pickers'

//Interface Imports
import { LicenseFieldsetProps, LicenseState } from './license-interface'
import { CloudUpload } from '@mui/icons-material'
import { VisuallyHiddenInput } from 'src/@core/theme/VisuallyHiddenInput'
import { getData } from 'src/api/axios'
import { useRouter } from 'next/router'
import GetConstructionTypeId from 'src/@core/components/get-construction-type'
import { formatDate } from 'src/@core/components/formater'

const LicenseFieldset: FC<LicenseFieldsetProps> = ({ data, onChange }) => {
  const router = useRouter()
  const [listLic, setListLic] = useState([])
  const [oldLic, setOldLic] = useState<any>([])
  const [fetching, setFetching] = useState(false)
  const [openModal, setOpenModal] = useState(false)
  const [fileUpload, setFileUpload] = useState<any>({
    fileGiayPhep: null,
    fileGiayToLienQuan: null,
    fileDonXinCP: null
  })
  const [giayphep, setGiayphep] = useState<LicenseState>({
    id: data?.id || 0,
    idCon: data?.idCon || null,
    idLoaiGP: data?.idLoaiGP || null,
    idTCCN: data?.idTCCN || null,
    tenGP: data?.tenGP || null,
    soGP: data?.soGP || null,
    ngayKy: data?.ngayKy || null,
    ngayCoHieuLuc: data?.ngayCoHieuLuc || null,
    ngayHetHieuLuc: data?.ngayHetHieuLuc || null,
    thoiHan: data?.thoiHan || null,
    fileGiayPhep: data?.fileGiayPhep || null,
    coQuanCapPhep: data?.coQuanCapPhep || null,
    fileGiayToLienQuan: data?.fileGiayToLienQuan || null,
    fileDonXinCP: data?.fileDonXinCP || null,
    congtrinh: data?.congtrinh || null,
    tiencq: data?.tiencq || null,
    tochuc_canhan: data?.tochuc_canhan || null
  })
  const loaiGP = [
    { title: 'Cấp mới giấy phép', value: 1 },
    { title: 'Cấp lại giấy phép', value: 2 },
    { title: 'Gia hạn giấy phép', value: 3 },
    { title: 'Điều chỉnh giấy phép', value: 4 },
    { title: 'Thu hồi giấy phép', value: 5 }
  ]

  const coQuanCapPhep = [
    { title: 'BTNMT', value: 'BTNMT' },
    { title: 'UBND Tỉnh', value: 'UBNDT' },
    ...(router.pathname === '/giay-phep/nuoc-duoi-dat/tham-do' ? [{ title: 'STNMT', value: 'STNMT' }] : [])
  ]

  const [customFileName, setCustomFileName] = useState('')

  useEffect(() => {
    const getDataForSelect = async () => {
      const paramsFilter = {
        so_gp: null,
        cong_trinh: null,
        coquan_cp: null,
        loaihinh_cp: 0,
        hieuluc_gp: null,
        loai_ct: GetConstructionTypeId(router),
        tang_chuanuoc: 0,
        huyen: 0,
        xa: 0,
        tieuvung_qh: 0,
        tochuc_canhan: 0,
        tu_nam: 0,
        den_nam: 0
      }
      setFetching(true)
      await getData('giay-phep/danh-sach', paramsFilter)
        .then(data => {
          setListLic(data)
        })
        .finally(() => {
          setFetching(false)
        })
    }
    getDataForSelect()
  }, [router])

  const handleChange = (prop: keyof LicenseState) => (value: any) => {
    setGiayphep({ ...giayphep, [prop]: value })
    onChange({ ...giayphep, [prop]: value }, fileUpload)
  }

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>, fileType: string) => {
    const file = event.target.files?.[0] || null

    const updatedFileUpload = { ...fileUpload }
    switch (fileType) {
      case 'fileGiayPhep':
        updatedFileUpload.fileGiayPhep = file
        break
      case 'fileDonXinCP':
        updatedFileUpload.fileDonXinCP = file
        break
      case 'fileGiayToLienQuan':
        if (file) {
          const renamedFile = new File([file], customFileName || file.name, {
            type: file.type,
            lastModified: file.lastModified
          })
          updatedFileUpload.fileGiayToLienQuan = renamedFile
        }
        break
      default:
        break
    }

    setFileUpload(updatedFileUpload)
    onChange(giayphep, updatedFileUpload)
  }

  const handleCustomFileName = (event: React.ChangeEvent<HTMLInputElement>) => {
    setCustomFileName(event.target.value)
  }

  return (
    <Box>
      <fieldset>
        <legend>
          <Typography variant={'subtitle1'} className='legend__title'>
            THÔNG TIN GIẤY PHÉP
          </Typography>
        </legend>
        <Grid container spacing={6}>
          <Grid item xs={12} md={6} sm={12}>
            <TextField
              required
              size='small'
              type='text'
              label='Số giấy phép'
              fullWidth
              placeholder=''
              value={giayphep.soGP || ''}
              onChange={event => handleChange('soGP')(event.target.value)}
            />
          </Grid>
          <Grid item xs={12} md={6} sm={12}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DatePicker
                label='Ngày ký'
                value={dayjs(giayphep.ngayKy)}
                onChange={(newngayKy: any) => handleChange('ngayKy')(newngayKy.toDate())}
                slotProps={{ textField: { size: 'small', fullWidth: true, required: true } }}
                format='DD/MM/YYYY'
              />
            </LocalizationProvider>
          </Grid>
          <Grid item xs={12} md={6} sm={12}>
            <TextField
              size='small'
              type='text'
              label='Tên văn bản'
              fullWidth
              placeholder=''
              value={giayphep.tenGP || ''}
              onChange={event => handleChange('tenGP')(event.target.value)}
            />
          </Grid>
          <Grid item xs={12} md={6} sm={12}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DatePicker
                label='Ngày có hiệu lực'
                value={dayjs(giayphep.ngayCoHieuLuc)}
                onChange={(newngayCoHieuLuc: any) => handleChange('ngayCoHieuLuc')(newngayCoHieuLuc.toDate())}
                slotProps={{ textField: { size: 'small', fullWidth: true, required: true } }}
                format='DD/MM/YYYY'
              />
            </LocalizationProvider>
          </Grid>
          <Grid item xs={12} md={6} sm={12}>
            <Autocomplete
              size='small'
              options={loaiGP}
              getOptionLabel={(option: any) => option.title}
              value={loaiGP.find(option => option.value === giayphep.idLoaiGP) || null}
              isOptionEqualToValue={(option: any) => option.value}
              onChange={(_, value) => handleChange('idLoaiGP')(value?.value || 1)}
              renderInput={params => <TextField required {...params} fullWidth label='Chọn loại hình CP' />}
            />
          </Grid>
          <Grid item xs={12} md={6} sm={12}>
            <TextField
              size='small'
              type='text'
              label='Thời hạn giấy phép'
              fullWidth
              placeholder=''
              value={giayphep.thoiHan || ''}
              onChange={event => handleChange('thoiHan')(event.target.value)}
            />
          </Grid>
          <Grid item xs={12} md={6} sm={12}>
            <Autocomplete
              size='small'
              options={coQuanCapPhep}
              getOptionLabel={(option: any) => option.title}
              value={coQuanCapPhep.find(option => option.value === giayphep.coQuanCapPhep) || null}
              isOptionEqualToValue={(option: any) => option.value}
              onChange={(_, value) => handleChange('coQuanCapPhep')(value?.value || 'UBNDT')}
              renderInput={params => <TextField required {...params} fullWidth label='Chọn cơ quan CP' />}
            />
          </Grid>
          <Grid item xs={12} md={6} sm={12}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DatePicker
                label='Ngày hết hiệu lực'
                value={dayjs(giayphep.ngayHetHieuLuc)}
                onChange={(newngayHetHieuLuc: any) => handleChange('ngayHetHieuLuc')(newngayHetHieuLuc.toDate())}
                slotProps={{
                  textField: {
                    size: 'small',
                    fullWidth: true,
                    required: giayphep.idLoaiGP == 5 ? false : true
                  }
                }}
                format='DD/MM/YYYY'
              />
            </LocalizationProvider>
          </Grid>
          {giayphep.idLoaiGP && giayphep.idLoaiGP > 1 && giayphep.idLoaiGP <= 5 ? (
            fetching ? (
              <CircularProgress size={20} />
            ) : (
              <Grid item xs={12} md={6} sm={12}>
                <Autocomplete
                  size='small'
                  options={listLic}
                  getOptionLabel={(option: any) => `${option.soGP} (Ký ngày: ${formatDate(option.ngayKy)})`}
                  isOptionEqualToValue={(option: any) => option.id}
                  value={listLic.find((option: any) => option.id === giayphep.idCon) || null}
                  onChange={(_, value) => {
                    handleChange('idCon')(value?.id || 0)
                    setOldLic(value || [])
                  }}
                  renderInput={params => <TextField required {...params} fullWidth label='Số giấy phép cũ' />}
                />
              </Grid>
            )
          ) : (
            ''
          )}
          {giayphep.idLoaiGP && giayphep.idLoaiGP > 1 && giayphep.idLoaiGP <= 5 ? (
            fetching ? (
              <CircularProgress size={20} />
            ) : (
              <Grid item xs={12} md={6} sm={12}>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DatePicker
                    disabled
                    label='Ngày ký giấy phép cũ'
                    value={dayjs(oldLic.ngayKy) || null}
                    slotProps={{ textField: { size: 'small', fullWidth: true, required: true } }}
                    format='DD/MM/YYYY'
                  />
                </LocalizationProvider>
              </Grid>
            )
          ) : (
            ''
          )}
        </Grid>
      </fieldset>
      <fieldset>
        <legend>
          <Typography variant={'subtitle1'} className='legend__title'>
            TÀI LIỆU ĐÍNH KÈM
          </Typography>
        </legend>
        <Grid container>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell align='center' sx={{ p: 0 }}>
                  Giấy phép
                </TableCell>
                <TableCell align='center' sx={{ p: 0 }}>
                  Đơn xin cấp phép
                </TableCell>
                <TableCell align='center' sx={{ p: 0 }}>
                  Tài liệu liên quan
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              <TableRow>
                <TableCell align='center'>
                  {fileUpload.fileGiayPhep && <Typography mb={3}>{fileUpload.fileGiayPhep?.name}</Typography>}
                  <Button
                    className='uploadBtn'
                    component='label'
                    variant='contained'
                    startIcon={<CloudUpload />}
                    href={`#fileGiayPhep`}>
                    Upload file
                    <VisuallyHiddenInput
                      type='file'
                      id='fileGiayPhep'
                      onChange={event => handleFileChange(event, 'fileGiayPhep')} // Pass the file type
                      accept='.pdf'
                    />
                  </Button>
                </TableCell>
                <TableCell align='center'>
                  {fileUpload.fileDonXinCP && <Typography mb={3}>{fileUpload.fileDonXinCP?.name}</Typography>}
                  <Button
                    className='uploadBtn'
                    component='label'
                    variant='contained'
                    startIcon={<CloudUpload />}
                    href={`#fileDonXinCP`}>
                    Upload file
                    <VisuallyHiddenInput
                      type='file'
                      id='fileDonXinCP'
                      onChange={event => handleFileChange(event, 'fileDonXinCP')} // Pass the file type
                      accept='.pdf'
                    />
                  </Button>
                </TableCell>
                <TableCell align='center'>
                  {fileUpload.fileGiayToLienQuan && (
                    <Typography mb={3}>{fileUpload.fileGiayToLienQuan?.name}</Typography>
                  )}
                  <Button
                    className='uploadBtn'
                    onClick={() => setOpenModal(true)}
                    variant='contained'
                    startIcon={<CloudUpload />}>
                    Upload file
                  </Button>
                  {openModal && (
                    <Modal open={openModal} onClose={() => setOpenModal(false)}>
                      <div
                        style={{
                          position: 'absolute',
                          top: '50%',
                          left: '50%',
                          transform: 'translate(-50%, -50%)',
                          backgroundColor: 'white',
                          padding: '20px',
                          borderRadius: '5px',
                          display: 'flex',
                          flexDirection: 'column',
                          gap: '16px',
                          minWidth: '400px'
                        }}>
                        <Typography variant='h6'>Giấy tờ liên quan(PDF)</Typography>
                        <Button
                          className='uploadBtn'
                          component='label'
                          variant='contained'
                          startIcon={<CloudUpload />}
                          href={`#fileGiayToLienQuan`}>
                          Chọn file
                          <VisuallyHiddenInput
                            type='file'
                            id='fileGiayToLienQuan'
                            onChange={event => handleFileChange(event, 'fileGiayToLienQuan')}
                            accept='.pdf'
                          />
                        </Button>
                        <TextField
                          fullWidth
                          size='small'
                          type='text'
                          placeholder='Tên tài liệu'
                          value={customFileName}
                          onChange={handleCustomFileName}
                        />
                        <Grid container columnSpacing={3}>
                          <Grid item sm={6}>
                            <Button
                              variant='contained'
                              fullWidth
                              color='primary'
                              onClick={() => {
                                if (fileUpload.fileGiayToLienQuan && customFileName) {
                                  const file = fileUpload.fileGiayToLienQuan
                                  const renamedFile = new File([file], customFileName, {
                                    type: file.type,
                                    lastModified: file.lastModified
                                  })
                                  setFileUpload({
                                    ...fileUpload,
                                    fileGiayToLienQuan: renamedFile
                                  })
                                  onChange(giayphep, {
                                    ...fileUpload,
                                    fileGiayToLienQuan: renamedFile
                                  })
                                }
                                setOpenModal(false)
                              }}>
                              Thêm
                            </Button>
                          </Grid>
                          <Grid item sm={6}>
                            <Button
                              variant='contained'
                              color='error'
                              fullWidth
                              onClick={() => {
                                if (fileUpload.fileGiayToLienQuan && customFileName) {
                                  setFileUpload({
                                    ...fileUpload,
                                    fileGiayToLienQuan: null
                                  })
                                  onChange(giayphep, {
                                    ...fileUpload,
                                    fileGiayToLienQuan: null
                                  })
                                }
                                setOpenModal(false)
                              }}>
                              Hủy
                            </Button>
                          </Grid>
                        </Grid>
                      </div>
                    </Modal>
                  )}
                </TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </Grid>
      </fieldset>
    </Box>
  )
}

export default LicenseFieldset
