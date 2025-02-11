import React, { useEffect, useState } from 'react'
// ** Types Import
import { Settings } from 'src/@core/context/settingsContext'
import { NavLink, NavSectionTitle, VerticalNavItemsType } from 'src/@core/layouts/types'

// ** Custom Menu Components
import VerticalNavLink from './VerticalNavLink'
import VerticalNavSectionTitle from './VerticalNavSectionTitle'
import { Box } from '@mui/material'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'

interface Props {
  settings: Settings
  navVisible?: boolean
  groupActive: string[]
  currentActiveGroup: string[]
  verticalNavItems?: VerticalNavItemsType
  saveSettings: (values: Settings) => void
  setGroupActive: (value: string[]) => void
  setCurrentActiveGroup: (item: string[]) => void
}

const resolveNavItemComponent = (item: NavLink | NavSectionTitle) => {
  if ((item as NavSectionTitle).sectionTitle) return VerticalNavSectionTitle

  return VerticalNavLink
}

const VerticalNavItems = (props: Props) => {
  // ** Props
  const { verticalNavItems } = props
  const { hasPermission } = useRequireAuth()
  const [menuItems, setMenuItems] = useState<JSX.Element[]>([])

  useEffect(() => {
    const RenderMenuItems = async () => {
      const permittedItems = await Promise.all(
        (verticalNavItems || []).map(async (item: NavLink | NavSectionTitle) => {
          const hasItemPermission = await hasPermission(item.path || '', 'view')
          item.permission = hasItemPermission

          if ('children' in item && item.children) {
            item.children = (
              await Promise.all(
                item.children.map(async (childItem: any) => {
                  if ('sectionTitle' in childItem) {
                    const hasChildPermission = await hasPermission(childItem.path || '', 'view')
                    childItem.permission = hasChildPermission
                  } else {
                    const pathWithoutLastSegment = childItem.path
                      ? childItem.path.split('/').slice(0, -1).join('/')
                      : ''
                    const hasChildPermission = await hasPermission(pathWithoutLastSegment || '', 'view')
                    childItem.permission = hasChildPermission
                  }

                  return childItem
                })
              )
            ).filter(childItem => childItem.permission)
          }

          return item
        })
      )

      const filteredItems = permittedItems.filter((item: NavLink | NavSectionTitle) => item !== null && item.permission)

      const renderedItems = filteredItems.map((item: NavLink | NavSectionTitle, index: number) => {
        const TagName: any = resolveNavItemComponent(item)

        return <TagName {...props} key={index} item={item} />
      })

      setMenuItems(renderedItems)
    }

    RenderMenuItems()
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [verticalNavItems, hasPermission])

  return <Box>{menuItems}</Box>
}

export default VerticalNavItems
