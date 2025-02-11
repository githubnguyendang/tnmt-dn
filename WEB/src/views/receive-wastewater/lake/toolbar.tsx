//import { Replay, Search } from '@mui/icons-material'
import { Button, Grid, SelectChangeEvent, TextField, Toolbar } from '@mui/material'
import { ChangeEvent, FC, useState } from 'react'
import { Replay, Search } from '@mui/icons-material'
import { useRouter } from 'next/router'
import ExportTableToExcel from 'src/@core/components/export-excel/export-csv'
import PhanDoanSongForm from './phan-doan-song/PhanDoanSongForm'
import CreateWasteForm from './wastewater-source/wasteWaterForm'
import CreateWasteFormDB from './dubao/wastewater-source/wasteWaterForm'

interface RiverToolBarProps {
  tabId:string|undefined
  onChange: (data: any, postSuccess?: boolean | undefined) => void
}

const ToolBar: FC<RiverToolBarProps> = ({ onChange,tabId }) => {
    const [postSucceed, setPostSucceed] = useState(false)
  const router = useRouter()
  const pathSegments = router.pathname.split('/')
  const handlePostSuccess = () => {
    setPostSucceed(prevState => !prevState)
    onChange(paramsFilter, postSucceed)
  }

  const section = pathSegments[4]
  const [paramsFilter, setParamsFilter] = useState({
    phanDoan: ''
  })

  const handleChange = (event: SelectChangeEvent | ChangeEvent<HTMLInputElement> | null) => (column: string) => {
    if (event) {
      if (event?.target) {
        setParamsFilter({ ...paramsFilter, [column]: event.target.value })
      } else {
        setParamsFilter({ ...paramsFilter, [column]: event })
      }
    }
  }

  const applyFilterChange = () => {
    onChange(paramsFilter)
  }

  const reloadData = () => {
    setParamsFilter(() => {
      const newParamsFilter = {
        phanDoan: ''
      }
      onChange({ ...newParamsFilter })

      return newParamsFilter
    })
  }

  return (
    <Toolbar variant='dense'>
      <Grid container spacing={2} className='_flexEnd'>
        <Grid item xs={12} md={4}>
          <TextField
            size='small'
            fullWidth
            variant='outlined'
            placeholder='Tên phân đoạn sông...'
            onChange={(e: any) => handleChange(e)('phanDoan')}
          />
        </Grid>
        <Grid item xs={6} md={1.5}>
          <Button variant='outlined' size='small' fullWidth startIcon={<Search />} onClick={applyFilterChange}>
            Tìm kiếm
          </Button>
        </Grid>
        <Grid item xs={6} md={1.5}>
          <Button variant='outlined' size='small' fullWidth startIcon={<Replay />} onClick={reloadData}>
            Tải lại
          </Button>
        </Grid>
        {section === 'phan-doan-song' ? ( 
          <>
            <Grid item xs={6} md={1.5}>
              <ExportTableToExcel tableId='phan_doan_song' filename='phandoansong' />
            </Grid>

            <Grid item xs={6} md={1.5}>
              <PhanDoanSongForm isEdit={false}  setPostSuccess={handlePostSuccess} />
            </Grid>
          </>
        ) 
        :section === 'du-lieu-nguon-nhan' ? ( 
            <>
              <Grid item xs={6} md={1.5}>
              <ExportTableToExcel tableId='du-lieu-nguon-thai-diem' filename='dulieuthaidiem' />
              </Grid>
  
              <Grid item xs={6} md={1.5}>
              <CreateWasteForm isEdit={false} setPostSuccess={handlePostSuccess} />
              </Grid>
            </>
          ) 

          :section === 'tai-luong-o-nhiem' ? ( 
            <>
              <Grid item xs={6} md={1.5}>
              <ExportTableToExcel tableId='tai-luong-o-nhiem' filename='tailuongonhiem' />
              </Grid>
            </>
          ) 
          :section === 'kha-nang-tiep-nhan-nuoc-thai-song' ? ( 
            <>
              <Grid item xs={6} md={1.5}>
              <ExportTableToExcel tableId='kha-nang-tiep-nhan-nuoc-thai-song' filename='khanangtiepnhannuocthaisong' />
              </Grid>
            </>
          )
          : null}
     {tabId == 'dubaonguonnuocnhan' ? ( 
          <>
            <Grid item xs={6} md={1.5}>
              <ExportTableToExcel tableId='phan_doan_song' filename='phandoansong' />
            </Grid>

            <Grid item xs={6} md={1.5}>
              <CreateWasteFormDB isEdit={false}  setPostSuccess={handlePostSuccess} />
            </Grid>
          </>
        ) : null} 
      </Grid>
    </Toolbar>
  )
}

export default ToolBar
