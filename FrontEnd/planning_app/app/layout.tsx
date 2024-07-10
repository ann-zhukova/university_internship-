import "./globals.css";
import { Layout, Menu } from "antd";
import { Content, Footer, Header } from "antd/es/layout/layout";
import Link from "next/link";

const items = [
  {key: "home", label: <Link href={"/"}>Home</Link>}, 
  {key: "Tasks", label: <Link href={"/tasks"}>Tasks</Link>}, 
  {key: "Projects", label: <Link href={"/projects"}>Projects</Link>},
  {key: "Workers", label: <Link href={"/workers"}>Workers</Link>},
];

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="ru">
      <body>
        <Layout>
          <Header>
            <Menu theme="dark" mode ="horizontal" items={items} style = {{flex:1, minWidth:0}}/>
          </Header>
          <Content style = {{padding: "0 48pcx"}}> {children}</Content>
         <Footer style = {{textAlign:"center"}}> Planning app created by Ann Zhukova</Footer>
        </Layout>
        
        </body>
    </html>
  );
}
