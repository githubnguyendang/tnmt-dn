import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import { useEffect, useState, useMemo } from 'react'
import HoChuaTren10TrieuM3 from 'src/views/ho-chua/tren-10trieu-m3'
import TrangChuVanHanhView from 'src/views/ho-chua'
import WaterResourcePage from '.'

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
      'tren-10trieu-m3': {
        'ho-chua': HoChuaTren10TrieuM3,
        default: WaterResourcePage
      },
    }),
    []
  )
  const typedType = Array.isArray(type) ? type[0] : type
  const typedPage = Array.isArray(page) ? page[0] : page

  const Component =
    typedType && typedPage && components[typedType]
      ? components[typedType][typedPage] || components[typedType].default || <div>Loading...</div>
      : TrangChuVanHanhView

  if (hasAccess === null) {
    return <div>Loading...</div>
  }

  return <Component />
}

export default HethongtuoiPage
