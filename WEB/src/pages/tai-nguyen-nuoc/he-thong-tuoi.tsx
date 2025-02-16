import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import { useEffect, useState, useMemo } from 'react'
import WaterResourcePage from '.'
import HoChua from 'src/views/cong-trinh-tuoi/ho-chua'

type ComponentMap = {
  [key: string]: {
    [key: string]: () => JSX.Element
  }
}

const HethongtuoiPage = () => {
  const router = useRouter()
  const { page, type } = router.query
  const { hasPermission } = useRequireAuth()
  const [hasAccess, setHasAccess] = useState<boolean | null>(null)

  useEffect(() => {
    const checkPermission = async () => {
      const result = await hasPermission(`${router.pathname}/${page}`, 'view')
      setHasAccess(result)
    }
    checkPermission()
  }, [hasPermission, page, router.pathname])

  const components: ComponentMap = useMemo(
    () => ({
      'ho-chua': {
        'cong-trinh-tuoi': HoChua,
        default: HethongtuoiPage
      },


    }),
    [

    ]
  )
  const typedType = Array.isArray(type) ? type[0] : type
  const typedPage = Array.isArray(page) ? page[0] : page

  const Component =
    typedType && typedPage && components[typedType]
      ? components[typedType][typedPage] || components[typedType].default || <div>Loading...</div>
      : WaterResourcePage

  if (hasAccess === null) {
    return <div>Loading...</div>
  }

  return <Component />
}

export default HethongtuoiPage
