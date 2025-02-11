import { useState, useEffect } from 'react'
import {
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography
} from '@mui/material'
import { formatDateTime } from 'src/@core/components/formater'
import { calculateMonitoringData } from 'src/@core/components/calculate-monitoring-data'

interface FormMonitoringSystemProps {
  dataStorage: any // Add maCT to props
  dataCons: any
}

const MonitoringSFData: React.FC<FormMonitoringSystemProps> = ({ dataStorage, dataCons }) => {
  const [time, setTime] = useState(new Date())
  useEffect(() => {
    const interval = setInterval(() => {
      setTime(new Date())
    }, 1000)

    return () => clearInterval(interval)
  }, [])

  const checkNullValue = (value: any) => {
    if (value == null || value == undefined) {
      return <span>-</span>
    } else {
      return value
    }
  }

  return (
    <Grid>
      <Typography sx={{ fontWeight: 600, fontSize: '0.875rem', display: 'flex', alignItems: 'center' }}>
        <img src='/images/icon/live.gif' width={25} height={20} alt='live' />
        &nbsp;Thời gian hiện tại: {time.toLocaleString('zh-HK', { hour12: false })}
      </Typography>
      

      <TableContainer component={Paper} sx={{ mt: 5 }}>
        <Table sx={{ minWidth: 650 }} aria-label='simple table'>
          <TableHead className='tableHead'>
            <TableRow>
              <TableCell size='small' align='center' rowSpan={2}>
                STT
              </TableCell>
              <TableCell size='small' align='center' rowSpan={2}>
                Thời gian
              </TableCell>
              <TableCell size='small' align='center' rowSpan={2}>
                Lượng mưa <br />
                (mm)
              </TableCell>
              <TableCell size='small' align='center' rowSpan={2}>
                Mực nước <br /> hạ lưu (m)
              </TableCell>
              <TableCell size='small' align='center' rowSpan={2}>
                Dung tích hồ <br /> (triệu m<sup>3</sup>)
              </TableCell>
              <TableCell size='small' align='center' rowSpan={2}>
                Q đến hồ
                <br /> (m<sup>3</sup>/s)
              </TableCell>
              <TableCell size='small' align='center' colSpan={3}>
                Mực nước thượng lưu hồ (m)
              </TableCell>
              <TableCell size='small' align='center' colSpan={3}>
                Q xả qua tràn (m<sup>3</sup>/s)
              </TableCell>
              <TableCell size='small' align='center' colSpan={3}>
                Q xả qua nhà máy (m<sup>3</sup>/s)
              </TableCell>
              <TableCell size='small' align='center' colSpan={3}>
                Q xả DCTT (m<sup>3</sup>/s)
              </TableCell>
              <TableCell size='small' align='center' colSpan={3}>
                Q về hạ du (m<sup>3</sup>/s)
              </TableCell>
              <TableCell size='small' align='center' rowSpan={2}>
                Dự kiến Q về hạ du <br /> trong 12h tới(m<sup>3</sup>/s)
              </TableCell>
              <TableCell size='small' align='center' rowSpan={2}>
                Mực nước hồ <br />
                dự kiến 12h tới (m)
              </TableCell>
            </TableRow>

            <TableRow>
              <TableCell size='small' align='center'>
                Yêu cầu
              </TableCell>
              <TableCell size='small' align='center'>
                Thực tế
              </TableCell>
              <TableCell size='small' align='center'>
                Chênh lệch
              </TableCell>
              <TableCell size='small' align='center'>
                Yêu cầu
              </TableCell>
              <TableCell size='small' align='center'>
                Thực tế
              </TableCell>
              <TableCell size='small' align='center'>
                Chênh lệch
              </TableCell>
              <TableCell size='small' align='center'>
                Yêu cầu
              </TableCell>
              <TableCell size='small' align='center'>
                Thực tế
              </TableCell>
              <TableCell size='small' align='center'>
                Chênh lệch
              </TableCell>
              <TableCell size='small' align='center'>
                Yêu cầu
              </TableCell>
              <TableCell size='small' align='center'>
                Thực tế
              </TableCell>
              <TableCell size='small' align='center'>
                Chênh lệch
              </TableCell>
              <TableCell size='small' align='center'>
                Yêu cầu
              </TableCell>
              <TableCell size='small' align='center'>
                Thực tế
              </TableCell>
              <TableCell size='small' align='center'>
                Chênh lệch
              </TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {dataStorage.map((row: any, index: any) => (
              <TableRow key={index}>
                <TableCell align='center'>{index + 1}</TableCell>
                <TableCell align='center'>{formatDateTime(row?.time)}</TableCell>
                <TableCell align='center'>{checkNullValue(dataCons.thongso.MUATHUONGLUU)}</TableCell>
                <TableCell align='center'>{checkNullValue(row?.data.HALUU)}</TableCell>
                <TableCell align='center'>{checkNullValue(dataCons.thongso.dungTichToanBo)}</TableCell>
                <TableCell align='center'>{checkNullValue(row?.data.QDEN)}</TableCell>
                <TableCell align='center'>{checkNullValue(dataCons.thongso.hThuongLuuTT)}</TableCell>
                <TableCell align='center'>{row.data.THUONGLUU}</TableCell>
                <TableCell align='center'>{calculateMonitoringData(dataCons.thongso.hThuongLuuTT,row.data.THUONGLUU)}</TableCell>
                <TableCell align='center'>{checkNullValue(dataCons.thongso.qXaTran)}</TableCell>
                <TableCell align='center'>{row.data.QUATRAN}</TableCell>
                <TableCell align='center'>{calculateMonitoringData(dataCons.thongso.qXaTran,row.data.QUATRAN)}</TableCell>
                <TableCell align='center'>{checkNullValue(dataCons.thongso.qktLonNhat)}</TableCell>
                <TableCell align='center'>{row.data.NHAMAY}</TableCell>
                <TableCell align='center'>{calculateMonitoringData(dataCons.thongso.qktLonNhat,row.data.NHAMAY)}</TableCell>
                <TableCell align='center'>{checkNullValue(dataCons.thongso.qtt)}</TableCell>
                <TableCell align='center'>{row.data.DCTT}</TableCell>
                <TableCell align='center'>{calculateMonitoringData(dataCons.thongso.qtt,row.data.DCTT)}</TableCell>
                <TableCell align='center'>{checkNullValue(dataCons.thongso.htoiThieu)}</TableCell>
                <TableCell align='center'>{row.data.LUULUONGHADU}</TableCell>
                <TableCell align='center'>{calculateMonitoringData(dataCons.thongso.htoiThieu,row.data.LUULUONGHADU)}</TableCell>
                <TableCell align='center'>-</TableCell>
                <TableCell align='center'>-</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Grid>
  )
}

export default MonitoringSFData
