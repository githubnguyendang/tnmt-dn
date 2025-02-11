import * as React from 'react'
import { Page, Document, pdfjs } from 'react-pdf'

pdfjs.GlobalWorkerOptions.workerSrc = `//cdnjs.cloudflare.com/ajax/libs/pdf.js/${pdfjs.version}/pdf.worker.js`

export default function VanHanhLienHoDayDu() {
  // Generate an array of <Page> components for all pages
  const renderPages = () => {
    const pages = []
    for (let pageNumber = 1; pageNumber <= 2; pageNumber++) {
      pages.push(
        <Page key={pageNumber} pageNumber={pageNumber} renderTextLayer={false} renderAnnotationLayer={false} />
      )
    }

    return pages
  }

  return <Document file={'public/pdf/Licenses/0/thuydien/911_QD-TTg_388756(1).pdf'}>{renderPages()}</Document>
}
