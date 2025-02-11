import Paper from '@mui/material/Paper'
import { Grid, Box, Button } from '@mui/material'

import { getData } from 'src/api/axios'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'

import TableComponent, { TableColumn } from 'src/@core/components/table'

import DeleteData from 'src/@core/components/delete-data'
import ToolBar from './toolbar'

import dynamic from 'next/dynamic'
import { KeyboardDoubleArrowDown, KeyboardDoubleArrowUp } from '@mui/icons-material'
import React from 'react'
import ViewAmountRain1HourData from './form/Mua1H'
import viewDetail from './viewDetail'

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false })

const LuongMuaHienTai = () => {
  const [data, setData] = useState<any[]>([])

  const [loading, setLoading] = useState(false)

  const [mapCenter] = useState([15.012172, 108.676488])
  const [mapZoom] = useState(10)
  const [selected, setSelected] = React.useState(true)

  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  useEffect(() => {
    async function getDataDuLieuTram() {
      setLoading(true)
      await getData('DuLieuTram/danh-sach')
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

    getDataDuLieuTram()
  }, [postSuccess])

  const columnsTable: TableColumn[] = [
    {
      id: 'stt',
      label: 'STT',
      minWidth: 80,
      align: 'center'
    },
    {
      id: 'tenTram',
      label: 'Trạm đo mưa',
      elm: (row: any) => viewDetail(row.tenTram),
      align: 'left'
    },
    { id: 'luongmua', label: 'Lượng mưa(mm)', align: 'center', minWidth: 140 },
    { id: 'ngay', label: 'Ngày', align: 'center', minWidth: 140 },
    { id: 'gio', label: 'Giờ', align: 'center', minWidth: 140 }
  ]

  return (
    <Grid container spacing={3}>
      <Grid item xs={7} md={7}>
        <ToolBar tableId='luongmuahientai' />
        {loading ? (
          <BoxLoading />
        ) : (
          <TableComponent
            id='luongmuahientai'
            columns={columnsTable}
            rows={data}
            loading={loading}
            pagination
            actions={(row: any) => (
              <Box>
                <DeleteData url={'DuLieuTram'} data={row} setPostSuccess={handlePostSuccess} />
                <Button>
                  <ViewAmountRain1HourData data={row} />
                </Button>
              </Box>
            )}
          />
        )}
      </Grid>
      <Grid item xs={5} md={5} sx={{ height: 'calc(100vh - 150px)' }}>
        <Paper elevation={3} sx={{ height: '100%', position: 'relative' }}>
          <Button
            className='toggle-legend'
            variant='outlined'
            onClick={() => {
              setSelected(!selected)
            }}>
            {selected ? <KeyboardDoubleArrowDown /> : <KeyboardDoubleArrowUp />}
          </Button>
          <Map center={mapCenter} zoom={mapZoom} showLabel={false} mapData={null} loading={false} />
        </Paper>
      </Grid>
    </Grid>
  )
}

export default LuongMuaHienTai
