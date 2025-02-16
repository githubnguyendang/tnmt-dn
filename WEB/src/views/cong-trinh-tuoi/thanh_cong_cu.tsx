import { Replay, Search } from '@mui/icons-material'
import {
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  TextField,
  Toolbar,
  ListSubheader
} from '@mui/material'
import { ChangeEvent, FC, useEffect, useState } from 'react'
import { useRouter } from 'next/router'
import { getData } from 'src/api/axios'
import GetConstructionTypeId from 'src/@core/components/get-construction-type'

interface ThanhCongCuGiamSatProps {
  onChange: (data: any, postSuccess?: boolean | undefined) => void
}
const ThanhCongCuGiamSat: FC<ThanhCongCuGiamSatProps> = ({ onChange }) => {
  // const [postSucceed, setPostSucceed] = useState(false)
  const router = useRouter()
  const [consTypes, setConsTypes] = useState([])
  const [paramsFilter, setParamsFilter] = useState({
    tenct: '',
    loai_ct: GetConstructionTypeId(router.query?.type as string),
    huyen: 0,
    xa: 0,
    song: 0,
    luuvuc: 0,
    tieu_luuvuc: 0,
    tang_chuanuoc: 0,
    nguonnuoc_kt: ''
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
        tenct: '',
        loai_ct: GetConstructionTypeId(router.query?.type as string),
        huyen: 0,
        xa: 0,
        song: 0,
        luuvuc: 0,
        tieu_luuvuc: 0,
        tang_chuanuoc: 0,
        nguonnuoc_kt: ''
      }
      onChange({ ...newParamsFilter })

      return newParamsFilter
    })
  }

  useEffect(() => {
    let isMounted = true

    const getDataForSelect = async () => {
      try {
        // constructiom type
        const ConsTypesData = await getData('loai-ct/danh-sach')

        // district
        // const districtsData = await getData('hanh-chinh/huyen/danh-sach')

        if (paramsFilter.huyen > 0) {
          // comunnes
          // const comunnesData = await getData(`hanh-chinh/xa/danh-sach/${paramsFilter.huyen}`)
          if (isMounted) {
            // setCommunes(comunnesData)
          }
        }

        if (isMounted) {
          setConsTypes(
            ConsTypesData.map((item: any) => {
              const section = router.query?.type
              switch (section) {
                case 'nuoc-mat':
                  if (item.idCha === 1) {
                    return item
                  }
                  break
                case 'nuoc-duoi-dat':
                  if (item.idCha === 2) {
                    return item
                  }
                  break
                case 'xa-thai':
                  if (item.idCha === 3) {
                    return item
                  }
                  break
                default:
                  const children =
                    item.idCha === 0 ? ConsTypesData.filter((childItem: any) => childItem.idCha === item.id) : []
                  const res = { ...(item.idCha === 0 ? { ...item, children } : undefined) }

                  return res
                  break
              }
            })
          )
          // setDistricts(districtsData)
        }
      } catch (error) {
        console.log(error)
      }
    }

    getDataForSelect()

    return () => {
      isMounted = false
    }
  }, [paramsFilter.huyen, router.query])

  return (
    <Toolbar variant='dense'>
      <Grid container spacing={2} sx={{ paddingY: 3 }}>
        <Grid item xs={12} md={3} py={0}>
          <TextField
            sx={{ p: 0 }}
            size='small'
            fullWidth
            variant='outlined'
            placeholder='Tên công trình...'
            onChange={(e: any) => handleChange(e)('tenct')}
          />
        </Grid>
        <Grid item xs={12} md={2} py={0}>
          <FormControl size='small' fullWidth>
            <InputLabel id='license-type-select'>Loại công trình</InputLabel>
            <Select
              labelId='license-type-select'
              id='demo-select-small'
              value={
                paramsFilter.loai_ct > 3 ? paramsFilter.loai_ct : GetConstructionTypeId(router.query?.type as string)
              }
              label='Loại công trình'
              onChange={(e: any) => handleChange(e)('loai_ct')}>
              <MenuItem value={GetConstructionTypeId(router.query?.type as string)}>Loại công trình</MenuItem>
              {router.query?.type == 'nuoc-mat' ||
              router.query?.type == 'nuoc-duoi-dat' ||
              router.query?.type == 'xa-thai'
                ? consTypes
                    .filter((item: any) => item !== undefined)
                    .map((e: any, i: number) => [
                      <MenuItem key={i} value={e.id}>
                        {e.tenLoaiCT}
                      </MenuItem>
                    ])
                : consTypes
                    .filter((item: any) => item?.children)
                    .map((e: any, i: number) => [
                      <ListSubheader key={`subheader-${i}`}>{e.tenLoaiCT}</ListSubheader>,
                      ...e.children.map((child: any, j: number) => (
                        <MenuItem key={`child-${j}`} value={child.id}>
                          {child.tenLoaiCT}
                        </MenuItem>
                      ))
                    ])}
            </Select>
          </FormControl>
        </Grid>

        <Grid item xs={6} md={1.5} py={0}>
          <Button variant='outlined' size='small' fullWidth startIcon={<Search />} onClick={applyFilterChange}>
            Tìm kiếm
          </Button>
        </Grid>
        <Grid item xs={6} md={1.5} py={0}>
          <Button variant='outlined' size='small' fullWidth startIcon={<Replay />} onClick={reloadData}>
            Tải lại
          </Button>
        </Grid>
      </Grid>
    </Toolbar>
  )
}

export default ThanhCongCuGiamSat
