import { FC, useEffect, useState } from 'react'
import {
  Alert,
  Backdrop,
  Box,
  Button,
  ButtonGroup,
  Fade,
  Grid,
  IconButton,
  Modal,
  Paper,
  Popover,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Typography
} from '@mui/material'
import dayjs from 'dayjs'
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { Add, Cancel, CloudUpload, Delete, Edit, Save } from '@mui/icons-material'
import { InspectState } from './inspect-interface'
import { VisuallyHiddenInput } from 'src/@core/theme/VisuallyHiddenInput'
import { formatDate } from 'src/@core/components/formater'

interface InspectFieldsetProps {
  data?: InspectState[] | null
  onChange: (data: InspectState[]) => void
}
const InspectFeild: FC<InspectFieldsetProps> = ({ data, onChange }) => {
  const initialInspects: InspectState[] = data
    ? data.map((e: InspectState) => ({
        id: e.id,
        soVanBan: e.soVanBan,
        thoiGian: dayjs(e?.thoiGian),
        tienPhat: e.tienPhat,
        dot: e.dot,
        donVi: e.donVi,
        ghiChu: e.ghiChu,
        taiLieu: e.taiLieu,
        fileUpload: null,
        daXoa: false // Ensure daXoa is included to match InspectState interface
      }))
    : []

  const [Inspects, setInspects] = useState<InspectState[]>(initialInspects)
  const [newInspectIndex, setNewInspectIndex] = useState(-1)
  const [newInspect, setNewInspect] = useState<InspectState>({
    id: undefined,
    soVanBan: undefined,
    thoiGian: undefined,
    tienPhat: undefined,
    dot: undefined,
    donVi: undefined,
    ghiChu: undefined,
    taiLieu: undefined,
    daXoa: false,
    fileUpload: null
  })
  const [deleteConfirmAnchorEl, setDeleteConfirmAnchorEl] = useState<HTMLButtonElement | null>(null)
  const deleteConfirmOpen = Boolean(deleteConfirmAnchorEl)
  const [deleteTargetIndex, setDeleteTargetIndex] = useState<number | null>(null)
  const [required, setRequire] = useState<string | null>(null)

  const DeleteRowData = (event: React.MouseEvent<HTMLButtonElement>, index: number) => {
    setDeleteConfirmAnchorEl(event.currentTarget)
    setDeleteTargetIndex(index)
  }

  const handleDeleteCancel = () => {
    setDeleteConfirmAnchorEl(null)
  }

  const handleDeleteConfirm = () => {
    if (deleteTargetIndex !== null) {
      deleteItem(deleteTargetIndex) // Pass the index here
      setDeleteTargetIndex(null)
    }

    setDeleteConfirmAnchorEl(null)
  }

  const deleteItem = (index: number) => {
    setInspects(prevItems => {
      const newItems = [...prevItems]
      const removedItem = newItems.splice(index, 1)[0]

      if (removedItem?.id !== undefined && removedItem?.id !== null && removedItem?.id > 0) {
        setInspects(prevItems => [...prevItems, { ...removedItem, daXoa: true }])
      }

      return newItems
    })

    // Call onChange after the state update
    onChange(Inspects)
    setDeleteConfirmAnchorEl(null)
  }

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0]

    if (file) {
      setNewInspect(prevItem => {
        const newItem: InspectState = { ...prevItem }

        newItem.fileUpload = file
        newItem.taiLieu = `${newItem.soVanBan?.replace(/\//g, '_').toLowerCase()}.pdf`

        return newItem
      })
    }
  }

  const handleChange = (prop: keyof InspectState) => (value: any) => {
    setNewInspect(prevItem => {
      const newItem: InspectState = { ...prevItem }

      ;(newItem as any)[prop] = value

      return newItem
    })
  }

  const [openModal, setOpenModal] = useState(false)
  const handleCloseModal = () => setOpenModal(false)
  const handleOpenModal = (index: number, e: any, func: 'add' | 'update') => {
    setOpenModal(true)
    setNewInspectIndex(index)
    if (func === 'add') {
      // Set all properties of newInspect to null
      const nullValue = Object.fromEntries(Object.keys(newInspect || {}).map(key => [key, null]))

      setNewInspect({ ...nullValue, daXoa: false, soVanBan: null, thoiGian: null, tienPhat: null, dot: null, ...e }) // Ensure daXoa is set to false and set other properties to null
    }

    if (func === 'update') {
      setNewInspect({ ...e })
    }
  }

  const handleSave = () => {
    if (newInspect.soVanBan !== undefined || newInspect.thoiGian !== undefined) {
      if (newInspectIndex > 0) {
        setInspects(prevItems => {
          const updatedItems = [...prevItems]
          updatedItems[newInspectIndex] = { ...newInspect }

          return updatedItems
        })
      } else {
        setInspects(prevItems => [...prevItems, newInspect])
      }

      onChange([...Inspects])
      setNewInspectIndex(-1)
      handleCloseModal()
    } else {
      setRequire('Số băn bản và Ngày ký không được để trống')
    }
  }

  const style = {
    position: 'absolute' as const,
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 600,
    bgcolor: 'background.paper',
    boxShadow: 24,
    pt: 2,
    px: 4,
    pb: 3
  }

  useEffect(() => {
    onChange(Inspects)
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [Inspects])

  return (
    <TableContainer component={Paper}>
      <fieldset>
        <legend>
          <Typography variant={'subtitle1'} className='legend__title'>
            THANH TRA KIỂM TRA
          </Typography>
        </legend>
        <Table sx={{ minWidth: 650 }} aria-label='simple table'>
          <TableHead>
            <TableRow>
              <TableCell size='small' align='center'>
                TT
              </TableCell>
              <TableCell size='small' align='center'>
                Số văn bản
              </TableCell>
              <TableCell size='small' align='center'>
                Đợt thanh tra
              </TableCell>
              <TableCell size='small' align='center'>
                Đơn vị thanh tra
              </TableCell>
              <TableCell size='small' align='center'>
                Ngày thanh tra
              </TableCell>
              <TableCell size='small' align='center'>
                Tổng số tiền phạt vi phạm hành chính
              </TableCell>
              <TableCell size='small' align='center'>
                Ghi chú
              </TableCell>
              <TableCell size='small' align='center'>
                Văn bản kết luận
              </TableCell>
              <TableCell size='small' align='center' padding='checkbox' rowSpan={2}>
                <Box>
                  <IconButton
                    aria-label='add'
                    className='tableActionBtn'
                    onClick={() => handleOpenModal(0, null, 'add')}>
                    <Add />
                  </IconButton>
                  <Modal
                    aria-labelledby='transition-modal-title'
                    aria-describedby='transition-modal-description'
                    open={openModal}
                    onClose={handleCloseModal}
                    closeAfterTransition
                    slots={{ backdrop: Backdrop }}
                    slotProps={{
                      backdrop: {
                        timeout: 500
                      }
                    }}>
                    <Fade in={openModal}>
                      <Box sx={{ ...style, width: 600 }}>
                        <Typography id='transition-modal-title' variant='h6' component='h2' align='center' py={3}>
                          THÔNG TIN THANH TRA KIỂM TRA
                        </Typography>
                        {required ? (
                          <Alert sx={{ my: 2 }} severity='warning'>
                            {required}
                          </Alert>
                        ) : null}
                        <Grid container spacing={4}>
                          <Grid item md={12}>
                            <TextField
                              name='soVanBan'
                              fullWidth
                              label='Số băn bản'
                              placeholder='Số băn bản'
                              size='small'
                              value={newInspect.soVanBan}
                              onChange={event => handleChange('soVanBan')(event.target.value)}
                            />
                          </Grid>
                          <Grid item md={12}>
                            <TextField
                              name='dot'
                              fullWidth
                              label='Đợt thanh tra'
                              placeholder='Đợt thanh tra'
                              size='small'
                              value={newInspect.dot}
                              onChange={event => handleChange('dot')(event.target.value)}
                            />
                          </Grid>
                          <Grid item md={12}>
                            <TextField
                              name='donVi'
                              fullWidth
                              label='Đơn vị thanh tra'
                              placeholder='Đơn vị thanh tra'
                              size='small'
                              value={newInspect.donVi}
                              onChange={event => handleChange('donVi')(event.target.value)}
                            />
                          </Grid>
                          <Grid item md={6}>
                            <LocalizationProvider dateAdapter={AdapterDayjs}>
                              <DatePicker
                                value={dayjs(newInspect.thoiGian)}
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
                              value={newInspect.tienPhat}
                              onChange={event => handleChange('tienPhat')(event.target.value)}
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
                              value={newInspect.ghiChu}
                              onChange={event => handleChange('ghiChu')(event.target.value)}
                            />
                          </Grid>
                          <Grid item md={12}>
                            {newInspect.fileUpload && <Typography mb={3}>{newInspect.fileUpload?.name}</Typography>}
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
                          <Button
                            startIcon={<Save />}
                            sx={{ ml: 1 }}
                            variant='outlined'
                            color='primary'
                            onClick={handleSave}>
                            Lưu
                          </Button>
                          <Button
                            startIcon={<Cancel />}
                            sx={{ ml: 1 }}
                            variant='outlined'
                            color='error'
                            onClick={handleCloseModal}>
                            Huỷ
                          </Button>
                        </Grid>
                      </Box>
                    </Fade>
                  </Modal>
                </Box>
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {Inspects.map((item, index) => (
              <TableRow key={index}>
                <TableCell className="text-center  size='small' align-middle font-13">{index + 1}</TableCell>
                <TableCell>{item.soVanBan}</TableCell>
                <TableCell>{item.dot}</TableCell>
                <TableCell>{item.donVi}</TableCell>
                <TableCell>{formatDate(item.thoiGian)}</TableCell>
                <TableCell>{item.tienPhat}</TableCell>
                <TableCell>{item.ghiChu}</TableCell>
                <TableCell>{item.fileUpload?.name}</TableCell>
                <TableCell size='small' align='center'>
                  <Box className='group_btn'>
                    <IconButton
                      aria-describedby={`${item.soVanBan}-${index}`}
                      onClick={() => handleOpenModal(index, item, 'update')}
                      data-row-id={`${item.soVanBan}-${index}`}>
                      <Edit className='tableActionBtn' />
                    </IconButton>
                    <IconButton
                      aria-describedby={`${item.soVanBan}-${index}`}
                      onClick={event => DeleteRowData(event, index)}
                      data-row-id={`${item.soVanBan}-${index}`}>
                      <Delete className='tableActionBtn deleteBtn' />
                    </IconButton>
                    <Popover
                      id={deleteConfirmOpen ? `${item.soVanBan}-${index}` : undefined}
                      open={deleteConfirmOpen}
                      anchorEl={deleteConfirmAnchorEl}
                      onClose={handleDeleteCancel}
                      anchorOrigin={{
                        vertical: 'bottom',
                        horizontal: 'left'
                      }}>
                      <Alert severity='warning'>
                        Xóa bản ghi này ?
                        <Box sx={{ justifyContent: 'center', paddingTop: 4, width: '100%' }}>
                          <ButtonGroup variant='outlined' aria-label='outlined button group'>
                            <Button size='small' onClick={() => handleDeleteConfirm()}>
                              Đúng
                            </Button>
                            <Button color='error' size='small' onClick={() => handleDeleteCancel()}>
                              Không
                            </Button>
                          </ButtonGroup>
                        </Box>
                      </Alert>
                    </Popover>
                  </Box>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </fieldset>
    </TableContainer>
  )
}

export default InspectFeild
