//React Imports

import React, { SyntheticEvent } from 'react'
import { useState, useEffect } from 'react'
import { getData } from 'src/api/axios'
import { KeyboardDoubleArrowDown, KeyboardDoubleArrowUp } from '@mui/icons-material'
import { Paper, Button, Box, Tab, Select, MenuItem, Typography } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'

import dynamic from 'next/dynamic'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import BoxLoading from 'src/@core/components/box-loading'
import TableComponent, { TableColumn } from 'src/@core/components/table'

const MapVHHC = dynamic(() => import('src/@core/components/map/mapVHHC'), { ssr: false })

const ThongTinHoChua = () => {
  const [value, setValue] = useState('1')
  const [data, setData] = useState<any[]>([])
  const [loading, setLoading] = useState(false)

  const handleChange = (event: SyntheticEvent, newValue: string) => {
    setValue(newValue)
  }

  const [mapCenter] = useState([15.012172, 108.676488])
  const [mapZoom] = useState(9)
  const [selected, setSelected] = useState(true)

  const [layer, setLayer] = useState('ban-do')

  useEffect(() => {
    const getDataVHHC_HoChua_ThongSoKT = async () => {
      setLoading(true)

      //API de lay du lieu tu sql: 'VHHC_HoChua_ThongSoKT/danh-sach'
      await getData('VHHC_HoChua_ThongSoKT/danh-sach')
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

    getDataVHHC_HoChua_ThongSoKT()
  }, [])

  const columnsTable: TableColumn[] = [
    {
      id: 'stt',
      label: 'STT'
    },
    {
      //Id là trường dữ liệu lưu trong csdl
      id: '#',
      label: 'Tên hồ chứa',
      minWidth: 200,
      elm: (row: any) => (
        <Typography sx={{ fontSize: 13 }} className='btnShowFilePdf'> 
          {row?.cT_ThongTin.tenCT} 
        </Typography>
      )
    },
    {
      //Id chỗ này để trống vì không có dl, chỉ để mở rộng colspan
      id: '#',
      label: 'Các đặc trưng lưu vực',
      children: [
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'thuocLVS',
          label: 'Thuộc LVS',
          minWidth: 100
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'fLv',
          label: (
            <span>
              {' '}
              F_lv <br /> (km2)
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'xTbNam',
          label: (
            <span>
              {' '}
              X tbnăm <br /> (mm)
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'qoTbNam',
          label: (
            <span>
              {' '}
              Qo tbnăm <br /> (m3/s){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
        }
      ]
    },
    {
      //Id chỗ này để trống vì không có dl, chỉ để mở rộng colspan
      id: '#',
      label: 'Lưu lượng đỉnh lũ ứng với tần suất:P=%',
      children: [
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'p002',
          label: 'P=0,02%',
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'p01',
          label: 'P=0,1%',
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'p02',
          label: 'P=0,2%',
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'p05',
          label: 'P=0,5%',
          minWidth: 100,
          align: 'center',
        }
      ]
    },
    {
      id: '#',
      label: 'Hồ chứa',
      children: [
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'mndbt',
          label: (
            <span>
              {' '}
              MNDBT <br /> (m){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.mndbt}</Typography>
          )
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'mnc',
          label: 'MNC (m)',
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.mnc}</Typography>
          )
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'mnMaxP002',
          label: (
            <span>
              {' '}
              MN Max <br /> (P=0,02%){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'mnMaxP01',
          label: (
            <span>
              {' '}
              MN Max <br /> (P=0,1%){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'mnMaxP02',
          label: (
            <span>
              {' '}
              MN Max <br /> (P=0,2%){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'mnMaxP05',
          label: (
            <span>
              {' '}
              MN Max <br /> (P=0,5%){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'wToanBo',
          label: (
            <span>
              {' '}
              W toàn bộ <br /> (Wtb)
            </span>
          ),
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.dungTichToanBo}</Typography>
          )
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'wHuuIch',
          label: (
            <span>
              {' '}
              W hữu ích <br />
              (Whi)
            </span>
          ),
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.dungTichHuuIch}</Typography>
          )
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'wNam',
          label: (
            <span>
              {' '}
              W năm <br />
              (Wni)
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'wNhieuNam',
          label: (
            <span>
              {' '}
              W nhiều năm <br />
              (Wnni)
            </span>
          ),
          minWidth: 100,
          align: 'center',
        },
        {
          //Id là trường dữ liệu lưu trong csdl
          id: 'wChet',
          label: (
            <span>
              {' '}
              W chết <br /> (Wc)
            </span>
          ),
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.dungTichChet}</Typography>
          )
        }
      ]
    },
    {
      id: '#',
      label: 'Lưu lượng qua nhà máy',
      children: [
        {
          id: 'qDamBao',
          label: (
            <span>
              {' '}
              Q đảm bảo <br /> (Qđb){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.qDamBao}</Typography>
          )
        },
        {
          id: 'qMin',
          label: (
            <span>
              {' '}
              Q nhỏ nhất <br /> (Qmin){' '}
            </span>
          ),
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.qtt}</Typography>
          )
        },
        {
          id: 'qMax',
          label: (
            <span>
              {' '}
              Q lớn nhất <br /> (Qmax)
            </span>
          ),
          minWidth: 100,
          align: 'center',
          elm: (row: any) => (
            <Typography sx={{ fontSize: 13 }}>{row?.cT_ThongTin.thongSo.qmaxNM}</Typography>
          )
        }
      ]
    },
    {
      id: 'ghiChu',
      label: 'Ghi chú'
    },
    { align: 'center', id: 'actions', label: 'Thao tác', minWidth: 100, rowspan: 3 }
  ]

  return (
    <Grid container spacing={2}>
      <Grid xs={12} md={12}>
        <TabContext value={value}>
          <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
            <TabList onChange={handleChange} aria-label='ground water reserve'>
              <Tab label='Thông số kỹ thuật hồ chứa ' value='1' />
              <Tab label='Quan hệ mực nước - dung tích' value='2' />
            </TabList>
          </Box>

          <TabPanel value='1'>
            <Grid xs={12} md={12} sx={{ height: 'calc(50vh - 82px)' }}>
              <Paper elevation={3} sx={{ height: '100%', position: 'relative' }}>
                <Select className='toggle-legend' value={layer} size='small' onChange={e => setLayer(e.target.value)}>
                  <MenuItem value={'ban-do'}>Bản đồ</MenuItem>
                  <MenuItem value={'so-do-thang'}>Sơ đồ thẳng</MenuItem>
                </Select>
                {layer && layer == 'ban-do' ? (
                  <MapVHHC center={mapCenter} zoom={mapZoom} showLabel={false} mapData={data} loading={false} type="road" />
                ) : (
                  <Box>Ảnh sơ đồ thẳng</Box>
                )}
              </Paper>
            </Grid>
            <Grid>
              {loading ? (
                <BoxLoading />
              ) : (
                <Grid className='_text_center' sx={{ mt: 3 }}>
                  <TableComponent
                    columns={columnsTable}
                    rows={data}
                    loading={loading}
                    pagination
                  />
                </Grid>
              )}
            </Grid>
          </TabPanel>

          <TabPanel value='2'>
            <Grid xs={12} md={12} sx={{ height: 'calc(50vh - 82px)' }}>
              <Paper elevation={3} sx={{ height: '100%', position: 'relative' }}>
                <Button
                  className='toggle-legend'
                  variant='outlined'
                  onClick={() => {
                    setSelected(!selected)
                  }}>
                  {selected ? <KeyboardDoubleArrowDown /> : <KeyboardDoubleArrowUp />}
                </Button>
                <MapVHHC center={mapCenter} zoom={mapZoom} showLabel={false} mapData={null} loading={false} />
              </Paper>
            </Grid>
            <Grid></Grid>
          </TabPanel>
        </TabContext>
      </Grid>
    </Grid>
  )
}

export default ThongTinHoChua
