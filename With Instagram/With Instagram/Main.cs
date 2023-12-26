﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
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

            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                // 파일에서 사용자 정보 읽기
                string filePath = "users.dat";
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            User user = new User
                            {
                                ID = parts[0],
                                Password = parts[1]
                            };
                            users.Add(user);
                            cboxID1.Items.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 정보를 불러오는 도중 오류가 발생했습니다: {ex.Message}");
            }
        }

        private void SaveUsers()
        {
            try
            {
                string filePath = "users.dat";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine($"{user.ID},{user.Password}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 정보를 저장하는 도중 오류가 발생했습니다: {ex.Message}");
            }
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

                // 유저정보 저장 .dat
                SaveUsers();

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

                SaveUsers();
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
            if (string.IsNullOrWhiteSpace(txtID1.Text))
            {
                MessageBox.Show("ID입력하세요");
                return;
            };

            // 실행 파일이 위치한 디렉토리를 기준으로 chromedriver.exe 경로 설정
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string chromeDriverRelativePath = $"chromedriver.exe";
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

                Thread.Sleep(1000);

                // ID 입력란의 XPath
                string idInputXPath = "//*[@id='loginForm']/div/div[1]/div/label/input";
                string pwInputXPath = "//*[@id='loginForm']/div/div[2]/div/label/input";
                string loginbtnXPath = "//*[@id='loginForm']/div/div[3]";

                // ID 입력란에 값을 입력
                IWebElement idInput = driver.FindElement(By.XPath(idInputXPath));
                idInput.SendKeys(txtID1.Text);
                Thread.Sleep(1000);
                IWebElement pwInput = driver.FindElement(By.XPath(pwInputXPath));
                pwInput.SendKeys(txtPW1.Text);
                Thread.Sleep(1000);
                IWebElement loginBtn = driver.FindElement(By.XPath(loginbtnXPath));
                loginBtn.Click();
            }
            catch (Exception ex)
            {
                // 에러 처리
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



        /*
        
        private void InitializeDriver()
        {
            string driverPath = DownloadLatestChromeDriver();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            // WebDriver 초기화
            IWebDriver driver = new ChromeDriver(driverPath, options);

            // 나머지 코드에서 이 driver를 사용할 수 있음
        }

        private string DownloadLatestChromeDriver()
        {
            // 최신 버전의 ChromeDriver를 다운로드할 URL
            string downloadUrl = "https://chromedriver.storage.googleapis.com/LATEST_RELEASE";

            // 최신 버전 가져오기
            WebClient client = new WebClient();
            string latestVersion = client.DownloadString(downloadUrl).Trim();

            // 최신 버전에 해당하는 ChromeDriver 다운로드 경로 생성
            string downloadPath = $"https://chromedriver.storage.googleapis.com/{latestVersion}/chromedriver_win32.zip";

            // WebDriver 다운로드
            string driverDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver");
            string zipFilePath = Path.Combine(driverDirectory, "chromedriver.zip");

            // TODO: 여기에 파일 다운로드 및 압축 해제 코드 추가

            return driverDirectory;
        }

        */

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
