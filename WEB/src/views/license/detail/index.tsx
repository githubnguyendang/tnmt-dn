import * as React from 'react'
import Dialog from '@mui/material/Dialog'
import DialogContent from '@mui/material/DialogContent'
import {
  Typography,
  Slide,
  Box,
  AppBar,
  Toolbar,
  Paper,
  Grid,
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody
} from '@mui/material'
import { TransitionProps } from '@mui/material/transitions'
import CloseIcon from '@mui/icons-material/Close'
import CheckEffect from '../check-effect'
import ShowFilePDF from 'src/@core/components/show-file-pdf'
import formatDate from 'src/@core/components/format-date'
import { formatNum } from 'src/@core/components/formater'

interface AlertDialogProps {
  data: any
}

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & {
    children: React.ReactElement
  },
  ref: React.Ref<unknown>
) {
  return <Slide direction='left' ref={ref} {...props} />
})

export default function AlertDialog({ data }: AlertDialogProps) {
  const [open, setOpen] = React.useState(false)

  const handleClickOpen = () => {
    setOpen(true)
  }

  const handleClose = () => {
    setOpen(false)
  }

  return (
    <React.Fragment>
      <Typography className='btnShowFilePdf' onClick={handleClickOpen}>
        {data?.soGP}
      </Typography>
      <Dialog
        open={open}
        onClose={handleClose}
        fullScreen
        TransitionComponent={Transition}
        className='DialogControlShowPDF'
        sx={{ zIndex: 1201 }}>
        <Box>
          <AppBar sx={{ position: 'sticky', top: 0, zIndex: 1201 }}>
            <Toolbar>
              <Typography sx={{ ml: 2, flex: 1, color: `#fff` }} variant='h6' component='div'>
                Chi tiết Giấy Phép
              </Typography>
              <CloseIcon className='btn' onClick={handleClose} />
            </Toolbar>
          </AppBar>
          <DialogContent sx={{ p: 0, width: { xs: '100vw', md: '65vw' } }}>
            <Box sx={{ padding: 3 }}>
              <Paper sx={{ marginBottom: 3, padding: 2 }}>
                <Typography variant='overline'>Thông Tin Chủ Giấy Phép</Typography>
                <Grid container spacing={2}>
                  <Grid item xs={6}>
                    <Typography fontSize={14} mb={3}>
                      <strong>Tên Chủ Giấy Phép:</strong> {data.tochuc_canhan.tenTCCN}
                    </Typography>
                  </Grid>
                  <Grid item xs={6}>
                    <Typography fontSize={14} mb={3}>
                      <strong>Địa Chỉ:</strong> {data.tochuc_canhan.diaChi}
                    </Typography>
                  </Grid>
                </Grid>
              </Paper>

              <Paper sx={{ marginBottom: 3, padding: 2 }}>
                <Typography variant='overline'>Thông tin Giấy Phép</Typography>
                <Grid container spacing={2}>
                  <Grid item xs={6}>
                    <Typography fontSize={14} mb={3}>
                      <strong>Số Giấy Phép:</strong> {data.soGP}
                    </Typography>
                    <Typography fontSize={14} mb={3}>
                      <strong>Ngày Ký:</strong> {formatDate(data.ngayKy)}
                    </Typography>
                    <Typography fontSize={14} mb={3}>
                      <strong>Thời Hạn:</strong> {data.thoiHan}
                    </Typography>
                  </Grid>
                  <Grid item xs={6}>
                    <Typography fontSize={14} mb={3}>
                      <strong>Cơ Quan Cấp Phép:</strong> {data.coQuanCapPhep}
                    </Typography>
                    <Typography fontSize={14} mb={3}>
                      <strong>Loại hình:</strong> {data.loaiGP?.tenLoaiGP}
                    </Typography>
                    <Typography fontSize={14} mb={3}>
                      <strong>Trạng Thái:</strong> {CheckEffect({ data: data, type: 'string' })}
                    </Typography>
                  </Grid>
                </Grid>
              </Paper>

              <Paper sx={{ marginBottom: 3, padding: 2 }}>
                <Typography variant='overline'>Thông Tin Công Trình</Typography>
                <Grid container spacing={2}>
                  <Grid item xs={6}>
                    <Typography fontSize={14} mb={3}>
                      <strong>Tên Công Trình:</strong> {data.congtrinh.tenCT}
                    </Typography>
                    <Typography fontSize={14} mb={3}>
                      <strong>Địa Chỉ:</strong> {data.congtrinh.viTriCT}
                    </Typography>
                  </Grid>
                  <Grid item xs={6}>
                    <Typography fontSize={14} mb={3}>
                      <strong>Loại Hình:</strong> {data.congtrinh.loaiCT.tenLoaiCT}
                    </Typography>
                    <Typography fontSize={14} mb={3}>
                      <strong>Nguồn nước {data.congtrinh.loaiCT.idCha !== 3 ? 'khai thác' : 'xả thải'} :</strong>{' '}
                      {data.congtrinh.nguonNuocKT}
                    </Typography>
                  </Grid>
                </Grid>
              </Paper>

              <Paper sx={{ marginBottom: 3, padding: 2 }}>
                <Typography variant='overline'>Tài liệu liên quan</Typography>
                <TableContainer component={Paper}>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>Tên tài liệu</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      <TableRow>
                        <TableCell>
                          <ShowFilePDF
                            name={data.fileGiayToLienQuan?.split('/').pop() || ''}
                            src={data.fileGiayToLienQuan}
                          />
                        </TableCell>
                      </TableRow>
                    </TableBody>
                  </Table>
                </TableContainer>
              </Paper>

              <Paper sx={{ marginBottom: 3, padding: 2 }}>
                <Typography variant='overline'>Thông tin tiền cấp quyền</Typography>
                <TableContainer component={Paper}>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>Quyết định cấp quyền</TableCell>
                        <TableCell>Tổng tiền cấp quyền</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {data.tiencq?.map((tcq: any, index: number) => (
                        <TableRow key={index}>
                          <TableCell>
                            <ShowFilePDF name={`${tcq?.soQDTCQ} - ${formatDate(tcq?.ngayKy)}`} src={tcq?.filePDF} />
                          </TableCell>
                          <TableCell>{formatNum(tcq.tongTienCQ)}</TableCell>
                        </TableRow>
                      ))}
                    </TableBody>
                  </Table>
                </TableContainer>
              </Paper>

              <Paper sx={{ marginBottom: 3, padding: 2 }}>
                <Typography variant='overline'>Lịch Sử Cấp Phép</Typography>
                <TableContainer component={Paper}>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>Số giấy phép</TableCell>
                        <TableCell>Hiệu lực</TableCell>
                        <TableCell>Nội Dung</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {data.lichSuCapPhep?.map((lic: any, index: number) => (
                        <TableRow key={index}>
                          <TableCell>
                            <ShowFilePDF name={`${lic?.soGP} - ${formatDate(lic?.ngayKy)}`} src={lic?.fileGiayPhep} />
                          </TableCell>
                          <TableCell>{CheckEffect({ data: lic, type: 'component' })}</TableCell>
                          <TableCell>{lic.tenGP}</TableCell>
                        </TableRow>
                      ))}
                    </TableBody>
                  </Table>
                </TableContainer>
              </Paper>

              <Paper sx={{ marginBottom: 3, padding: 2 }}>
                <Typography variant='overline'>Lịch Sử Cấp Phép của tổ chức, cá nhân</Typography>
                <TableContainer component={Paper}>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>Số giấy phép</TableCell>
                        <TableCell>Hiệu lực</TableCell>
                        <TableCell>Nội Dung</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {data.giayPhepCuaToChuc?.map((lic: any, index: number) => (
                        <TableRow key={index}>
                          <TableCell>
                            <ShowFilePDF name={`${lic?.soGP} - ${formatDate(lic?.ngayKy)}`} src={lic?.fileGiayPhep} />
                          </TableCell>
                          <TableCell>{CheckEffect({ data: lic, type: 'component' })}</TableCell>
                          <TableCell>{lic.tenGP}</TableCell>
                        </TableRow>
                      ))}
                    </TableBody>
                  </Table>
                </TableContainer>
              </Paper>
            </Box>
          </DialogContent>
        </Box>
      </Dialog>
    </React.Fragment>
  )
}
