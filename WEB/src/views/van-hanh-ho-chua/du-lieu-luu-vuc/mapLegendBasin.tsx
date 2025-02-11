import React, { FC, Fragment, useEffect, useState } from 'react'
import Checkbox from '@mui/material/Checkbox'
import FormControlLabel from '@mui/material/FormControlLabel'
import List from '@mui/material/List'
import { Box, Typography } from '@mui/material'

const MapLegendBasinChild = ({ nodes, checkedItems, onCheck, findItemChildren }: any) => {
  return (
    <List sx={{ p: 0, textAlign: 'left' }}>
      {nodes.map(
        (node: {
          id: React.Key | null | undefined
          label: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined
          children: string | any[]
        }) => {
          const labelId = `checkbox-list-label-${node.id}`

          return (
            <Box key={node.id}>
              <FormControlLabel
                control={
                  <Checkbox
                    sx={{ py: 0, pl: 4, pr: 1 }}
                    onChange={onCheck(node.id)}
                    edge='start'
                    checked={checkedItems.includes(node.id)}
                    indeterminate={
                      findItemChildren(node.id).some((childId: any) => checkedItems.includes(childId)) &&
                      !checkedItems.includes(node.id)
                    }
                    disableRipple
                    inputProps={{ 'aria-labelledby': labelId }}
                  />
                }
                label={
                  <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex' }}>
                    <span>&nbsp;{node.label}</span>
                  </Typography>
                }
              />
              {node.children?.length > 0 && (
                <MapLegendBasinChild
                  nodes={node.children}
                  checkedItems={checkedItems}
                  onCheck={onCheck}
                  findItemChildren={findItemChildren}
                />
              )}
            </Box>
          )
        }
      )}
    </List>
  )
}

interface MapLegendBasinProps {
  onChange: (data: any) => void
}

const MapLegendBasin: FC<MapLegendBasinProps> = ({ onChange }) => {
  const [consType, setConsType] = useState<any>([])
  const [initialItems, setInitialItems] = useState<any>([
    'BaiCa',
    'Thoa',
    'TraBong',
    'TraKhuc',
    'Ve',
    'VucHong',
  ])
  const [checkedItems, setCheckedItems] = useState(initialItems)

  useEffect(() => {
    setConsType([
        {
          id: 'luuvuc',
          label: 'LƯU VỰC',
          children: [
            { label: 'LV Sông Bài Ca', id: 'BaiCa' },
            { label: 'LV Sông Thoa', id: 'Thoa' },
            { label: 'LV Sông Trà Bồng', id: 'TraBong' },
            { label: 'LV Sông Trà Khúc', id: 'TraKhuc' },
            { label: 'LV Sông Vệ', id: 'Ve' },
            { label: 'LV Sông Vực Hồng', id: 'VucHong' }
          ]
        }
      ])
      setInitialItems(['BaiCa', 'Thoa', 'TraBong', 'TraKhuc', 'Ve', 'VucHong'])
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  const findItemChildren = (parentId: any) => {
    const parentItem = consType.find((item: any) => item.id === parentId)
    if (!parentItem) return []

    const childrenIds: any = []

    const traverseChildren = (item: any) => {
      if (item.children?.length === 0) return
      item.children?.forEach((child: any) => {
        childrenIds.push(child.id)
        traverseChildren(child)
      })
    }

    traverseChildren(parentItem)

    return childrenIds
  }

  const handleCheckboxChange = (item: string) => () => {
    setCheckedItems((prevCheckedItems: any) => {
      const currentIndex = prevCheckedItems.indexOf(item)
      let newChecked: string[] = []

      if (currentIndex === -1) {
        newChecked = [...prevCheckedItems, item]
        const childrenIds = findItemChildren(item)
        newChecked.push(...childrenIds.filter((childId: any) => !prevCheckedItems.includes(childId))) // Only push unchecked children
      } else {
        newChecked = prevCheckedItems.filter((checkedId: any) => checkedId !== item)
        const childrenIds = findItemChildren(item)
        newChecked = newChecked.filter(checkedId => !childrenIds.includes(checkedId))
      }

      return newChecked
    })
  }

  onChange(checkedItems)

  const renderTree = (nodes: any) => (
    <Fragment>
      {nodes.map((node: any) => {
        return (
          <Box key={node.id} sx={{ display: 'flex', flexDirection: 'column', mx: 4 }}>
            <Typography variant='overline' sx={{ fontWeight: 'bold', background: '#035291', color: '#fff', mb: 1 }}>
                {node.label}
            </Typography>
            {node.children.length > 0 && (
              <MapLegendBasinChild
                nodes={node.children}
                checkedItems={checkedItems}
                onCheck={handleCheckboxChange}
                findItemChildren={findItemChildren}
              />
            )}
          </Box>
        )
      })}
    </Fragment>
  )

  return <div>{renderTree(consType)}</div>
}

export default MapLegendBasin
