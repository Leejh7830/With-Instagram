using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace With_Instagram
{
    public partial class MainForm : Form
    {
        private readonly List<User> users;
        private IWebDriver driver;

        public MainForm()
        {
            InitializeComponent();
            users = new List<User>();
        }

        private void BtnSave_Click(object sender, EventArgs e)
         {
            //List<User> users = new List<User>();
            string newID = txtID1.Text;
            string newPassword = txtPW1.Text;

            // 사용자가 ID와 PW를 입력했는지 확인
            if (string.IsNullOrWhiteSpace(newID) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("ID와 비밀번호를 모두 입력하세요.");
                return;
            }

            // 이미 동일한 ID가 있는지 확인
            User existingUser = users.FirstOrDefault(user => user.ID == newID);

            if (existingUser != null)
            {
                // 이미 있는 사용자의 비밀번호를 업데이트
                existingUser.Password = newPassword;
                MessageBox.Show("비밀번호가 업데이트되었습니다.");
            }
            else
            {
                // 새로운 사용자를 추가
                User user = new User
                {
                    ID = newID,
                    Password = newPassword
                };
                users.Add(user);
                cboxID1.Items.Add(user);
                MessageBox.Show("새로운 사용자가 추가되었습니다.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (cboxID1.SelectedItem != null)
            {
                User selectedUser = (User)cboxID1.SelectedItem;

                // 해당 사용자를 리스트에서 삭제
                users.Remove(selectedUser);

                // 콤보박스에서도 해당 사용자를 삭제
                cboxID1.Items.Remove(selectedUser);

                // 텍스트 상자 초기화
                txtID1.Clear();
                txtPW1.Clear();

                MessageBox.Show("사용자가 삭제되었습니다.");
            }
            else
            {
                MessageBox.Show("삭제할 사용자를 선택하세요.");
            }
        }

        private void cboxID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxID1.SelectedItem != null)
            {
                User selectedUser = (User)cboxID1.SelectedItem;
                txtID1.Text = selectedUser.ID;
                txtPW1.Text = selectedUser.Password;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // 실행 파일이 위치한 디렉토리를 기준으로 chromedriver.exe 경로 설정
            string executableLocation = AppDomain.CurrentDomain.BaseDirectory;
            string chromeDriverRelativePath = @"..\..\packages\Selenium.WebDriver.ChromeDriver.117.0.5938.14900\driver\win32\chromedriver";
            string chromeDriverPath = Path.GetFullPath(Path.Combine(executableLocation, chromeDriverRelativePath));

            // 크롬 드라이버 옵션 설정
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized"); // 창을 최대화하여 열기

            // 크롬 드라이버 실행
            driver = new ChromeDriver(chromeDriverPath, options);

            try
            {
                // 인스타그램 홈페이지로 이동
                driver.Navigate().GoToUrl("https://www.instagram.com/");
            }
            catch (Exception ex)
            {
                // 에러 처리
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 폼이 닫힐 때 WebDriver 종료
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

    }
}
