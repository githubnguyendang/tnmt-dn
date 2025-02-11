//React Imports

import { Box, Grid, Paper, Typography } from '@mui/material'
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import dayjs from 'dayjs'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'
import { getData } from 'src/api/axios'
import KQCLNuocMatForm from './KQCLNuocMatForm'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import DeleteData from 'src/@core/components/delete-data'

const KQCLNuocMat = () => {
  const [data, setData] = useState<any[]>([])
  console.log(data);
  
  const [loading, setLoading] = useState(false)
  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  const [year, setYear] = useState(new Date().getFullYear() - 1)
  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT' },
    {
      id: '#',
      label: 'Ký hiệu NM',
      align: 'left',
      minWidth: 200,
      elm: (row: any) => <span>{row.diemQuanTrac.tenDiemDo}</span>
    },
    {
      id: '#',
      label: 'Vị trí điểm đo',
      align: 'left',
      minWidth: 200,
      elm: (row: any) => <span>{row.diemQuanTrac.viTriQuanTrac}</span>
    },
    {
      id: 'dot',
      label: 'Đợt đo',
      align: 'left',
      minWidth: 150
    },
    {
      id: '#',
      label: 'Thông số',
      align: 'left',
      children: [
        {
          id: 'ph',
          label: 'PH',
          align: 'left'
        },
        {
          id: 'do',
          label: 'DO(mg/l)',
          align: 'left'
        },
        {
          id: 'tss',
          label: 'TSS(mg/l)',
          align: 'left'
        },
        {
          id: 'bod',
          label: 'BOD5 (mg/l)',
          align: 'left'
        },
        {
          id: 'cod',
          label: 'COD (mg/l)',
          align: 'left'
        },
        {
          id: 'nO3',
          label: (
            <Box>
              NO<sub>3</sub>- <sup>- </sup>N (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'nO2',
          label: (
            <Box>
              NO<sub>2</sub>- <sup>- </sup>N (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'pO4',
          label: (
            <Box>
              PO<sub>4</sub>3- <sub>- </sub>N (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'nH4',
          label: (
            <Box>
              NH<sub>4</sub>+ <sup>- </sup>N (mg/l)
            </Box>
          ),
          align: 'left'
        },
        {
          id: 'cl',
          label: 'Cl- (mg/l)',
          align: 'left'
        },
        {
          id: 'fe',
          label: 'Fe(mg/l)',
          align: 'left'
        },
        {
          id: 'coliform',
          label: 'Coliform (MPN/100ml)',
          align: 'left'
        }
      ]
    },
    { id: 'actions', label: 'Thao tác', align: 'center', pinned: 'right' }
  ]

  useEffect(() => {
    async function getDataWasteWater() {
      setLoading(true)
      await getData('ThongSoDiemQuanTrac/danh-sach', { nam: year })
        .then(data => {
          setData(data)
        })
        .catch(error => {
          console.log(error)
        })
        .finally(() => {
          setLoading(false)
        })
    }

    getDataWasteWater()
  }, [year, postSuccess])

  return (
    <>
      <Grid className='_text_center'>
        <Typography className='font-weight-bold' variant='body1' textTransform={'uppercase'}>
          KẾT QUẢ QUAN TRẮC MÔI TRƯỜNG TỈNH QUẢNG NGÃI
          <br />2 ĐỢT, NĂM 2021
          <br />
          KẾT QUẢ PHÂN TÍCH CHẤT LƯỢNG NƯỚC MẶT
        </Typography>
      </Grid>

      <Typography className='font-weight-bold _text_center' variant='h6'>
        <Box sx={{ width: 100, ml: 2, mt: 4, display: 'inline-block' }}>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DatePicker
              label='Năm'
              views={['year']}
              value={dayjs(new Date(year, 1, 1))}
              onChange={newVal => setYear(dayjs(newVal).year())}
              slotProps={{ textField: { size: 'small', required: true } }}
            />
          </LocalizationProvider>
        </Box>
      </Typography>
      {loading ? (
        <BoxLoading />
      ) : (
        <Grid item xs={12}>
          <Paper elevation={3} sx={{ p: 0, height: '100%' }}>
            <Grid container className='_flexEnd' spacing={2} sx={{ p: 2 }}>
              <Grid item>
                <ExportTableToExcel tableId={'KQCLNuocMat'} filename={'KQCLNuocMat'} />
              </Grid>
              <Grid item>
                <KQCLNuocMatForm isEdit={false} setPostSuccess={handlePostSuccess} />
              </Grid>
            </Grid>
            <TableComponent
              columns={columnsTable}
              rows={data}
              id='phan_doan_song'
              loading={loading}
              pagination
              actions={(row: any) => (
                <Box className='group_btn'>
                  <KQCLNuocMatForm isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                  <DeleteData url={'du-lieu-nguon-thai'} data={row} setPostSuccess={handlePostSuccess} />
                </Box>
              )}
            />
          </Paper>
        </Grid>
      )}
    </>
  )
}

export default KQCLNuocMat
